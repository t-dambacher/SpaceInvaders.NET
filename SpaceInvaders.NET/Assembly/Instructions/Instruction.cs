using SpaceInvaders.Debugging;
using SpaceInvaders.Processing;
using System;

namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// A 8080 comprehensible instruction that could be executed
    /// </summary>
    abstract public class Instruction
    {
        #region Constants

        /// <summary>
        /// Size, in bytes, of an OpCode
        /// </summary>
        private const ushort OpCodeSize = 1;

        /// <summary>
        /// Separator for <see cref="ToString"/> operations
        /// </summary>
        protected const string StringSeparator = "\t";

        #endregion

        #region Properties

        /// <summary>
        /// The address of the current instruction
        /// </summary>
        public ushort Address { get; }

        /// <summary>
        /// The OpCode that represents the operation to execute
        /// </summary>
        public OpCode OpCode { get; }

        /// <summary>
        /// The size of the current instruction, in bytes
        /// </summary>
        public ushort Size { get; }

        /// <summary>
        /// Debugger instance
        /// </summary>
        protected Debugger Debugger => Debugger.Instance;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Instruction"/>
        /// </summary>
        protected Instruction(ushort address, OpCode opCode)
        {
            this.Address = address;
            this.OpCode = opCode;
            this.Size = (ushort)(OpCodeSize + GetExtraDataSize(OpCode));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the current instruction by updating the given processor's state
        /// </summary>
        public void Execute(IExecutionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            ExecuteInternal(context);
            Advance(context);
        }

        /// <summary>
        /// Internal execution of the current instruction
        /// </summary>
        abstract protected void ExecuteInternal(IExecutionContext context);

        /// <summary>
        /// Advance the position of the program counter
        /// </summary>
        virtual protected void Advance(IExecutionContext context)
        {
            context.Memory.Advance(Size);
        }

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        override public string ToString()
        {
            return Address.ToString("X4") + StringSeparator + ((ushort)OpCode).ToString("X4") + StringSeparator + OpCode.ToString();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates a new <see cref="Instruction"/> based on the given informations
        /// </summary>
        static public Instruction FromOpCode(ushort address, OpCode opCode, byte[] data)
        {
            int dataSize = GetExtraDataSize(opCode);
            if (dataSize != data?.Length)
                throw new ArgumentException("The size of data do not match its expected value.", nameof(data));

            switch (opCode)
            {
                case OpCode.NOP: return new NopInstruction(address);
                case OpCode.LXIBD16: return new LXIBD16Instruction(address, data[0], data[1]);
                case OpCode.JMP: return new JmpInstruction(address, data[0], data[1]);
                case OpCode.LXISPD16: return new LXISPD16Instruction(address, data[0], data[1]);
                case OpCode.MVIBD8: return new MVIBD8Instruction(address, data[0]);
                case OpCode.CALL: return new CallInstruction(address, data[0], data[1]);
                case OpCode.LXIDD16: return new LXIDD16Instruction(address, data[0], data[1]);
                case OpCode.LXIHD16: return new LXIHD16Instruction(address, data[0], data[1]);
                case OpCode.LDAXD: return new LDAXDInstruction(address);
                case OpCode.MOVMA: return new MOVMAInstruction(address);
                case OpCode.INXH: return new INXHInstruction(address);
                case OpCode.INXD: return new INXDInstruction(address);
                case OpCode.DCRB: return new DCRBInstruction(address);
                case OpCode.JNZ: return new JNZInstruction(address, data[0], data[1]);
                case OpCode.RET: return new RETInstruction(address);
                case OpCode.MVIMD8: return new MVIMD8Instruction(address, data[0]);
                case OpCode.MOVAH: return new MOVAHInstruction(address);
                case OpCode.CPID8: return new CPID8Instruction(address, data[0]);
                default:
                    return new NotImplementedInstruction(address, opCode);
            }
        }

        /// <summary>
        /// Returns the size of a given instruction by its <see cref="OpCode"/>
        /// </summary>
        static public ushort GetExtraDataSize(OpCode opCode)
        {
            if (!Enum.IsDefined(typeof(OpCode), opCode))
                throw new ArgumentException($"The {opCode.ToString("X4")} is unknown.", nameof(opCode));

            switch (opCode)
            {
                case OpCode.LXIBD16:
                case OpCode.LXIDD16:
                case OpCode.LXIHD16:
                case OpCode.SHLD:
                case OpCode.LHLD:
                case OpCode.LXISPD16:
                case OpCode.STA:
                case OpCode.LDA:
                case OpCode.JNZ:
                case OpCode.JMP:
                case OpCode.CNZ:
                case OpCode.JZ:
                case OpCode.CZ:
                case OpCode.CALL:
                case OpCode.JNC:
                case OpCode.CNC:
                case OpCode.JC:
                case OpCode.CC:
                case OpCode.JPO:
                case OpCode.CPO:
                case OpCode.JPE:
                case OpCode.CPE:
                case OpCode.JP:
                case OpCode.CP:
                case OpCode.JM:
                case OpCode.CM:
                    return 2;
                case OpCode.MVIBD8:
                case OpCode.MVICD8:
                case OpCode.MVIDD8:
                case OpCode.MVIED8:
                case OpCode.MVIHD8:
                case OpCode.MVILD8:
                case OpCode.MVIMD8:
                case OpCode.MVIAD8:
                case OpCode.ADID8:
                case OpCode.ACID8:
                case OpCode.OUTD8:
                case OpCode.SUID8:
                case OpCode.IND8:
                case OpCode.SBID8:
                case OpCode.ANID8:
                case OpCode.XRID8:
                case OpCode.ORID8:
                case OpCode.CPID8:
                    return 1;
                default:
                    return 0;
            }
        }

        #endregion
    }
}
