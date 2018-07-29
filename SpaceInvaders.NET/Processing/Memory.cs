using System;
using System.Collections.Generic;
using System.Linq;
using SpaceInvaders.Assembly;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// Objet representing the underlying memory
    /// </summary>
    sealed public class Memory
    {
        #region Properties

        /// <summary>
        /// Pointer to the current instruction
        /// </summary>
        public ushort ProgramCounter { get; private set;}

        /// <summary>
        /// Byte in memory
        /// </summary>
        public byte this[ushort index]
        {
            get => GetByteAt(index);
            set { this.buffer[index] = value; }
        }

        /// <summary>
        /// Current instruction executing
        /// </summary>
        public Instruction Current => GetCurrentInstruction();

        #endregion

        #region Instance variables

        readonly private byte[] buffer;
        private IReadOnlyDictionary<ushort, Instruction> addressedInstructions;

        #endregion

        #region Constants

        /// <summary>
        /// The starting address of the RAM in memory
        /// </summary>
        private const ushort RamOffset = 0x2000;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new empty instance of a <see cref="Memory"/>
        /// </summary>
        internal Memory()
        {
            this.buffer = new byte[8 * 1024];   // the game has 8k of RAM and starts at 0x2000
        }

        #endregion

        #region Methods

        /// <summary>
        /// Moves the position of the <see cref="ProgramCounter"/> to the given position
        /// </summary>
        public void MoveTo(ushort position)
        {
            this.ProgramCounter = position;
        }

        /// <summary>
        /// Advances the position of the <see cref="ProgramCounter"/> for as much as asked in the <see cref="value"/>
        /// </summary>
        public void Advance(ushort value = 1)
        {
            this.ProgramCounter += value;
        }

        /// <summary>
        /// Loads the given instructions set in memory
        /// </summary>
        public void Load(IEnumerable<Instruction> instructions)
        {
            if (instructions == null)
                throw new ArgumentNullException(nameof(instructions));

            addressedInstructions = instructions.OrderBy(i => i.Address).ToDictionary(i => i.Address);
        }

        private Instruction GetCurrentInstruction()
        {
            if (addressedInstructions == null)
                return null;

            if (ProgramCounter == 0x00)
                return addressedInstructions.Values.FirstOrDefault();

            if (!addressedInstructions.TryGetValue(this.ProgramCounter, out Instruction instruction))
                throw new AccessViolationException($"The instruction at address {this.ProgramCounter} was not found in the current instruction set.");

            return instruction;
        }

        private byte GetByteAt(ushort address)
        {
            if (address < RamOffset)
                return (byte)this.addressedInstructions[address].OpCode;    // todo: could not work if we ask for an other thing than the OpCode, like the operand values...

            return buffer[address - RamOffset];
        }

        #endregion
    }
}
