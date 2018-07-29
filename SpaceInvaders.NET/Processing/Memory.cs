using SpaceInvaders.Assembly;
using System;
using System.IO;

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
        /// Returns the byte at the current position
        /// </summary>
        public byte Current => GetRelative(0);

        /// <summary>
        /// Byte in memory
        /// </summary>
        public byte this[ushort index]
        {
            get { return buffer[index]; }
            set { buffer[index] = value; }
        }

        /// <summary>
        /// Current instruction executing
        /// </summary>
        public Instruction CurrentInstruction => GetCurrentInstruction();

        #endregion

        #region Instance variables

        readonly private byte[] buffer;
        readonly private Disassembler disassembler;

        #endregion
       
        #region Constructor

        /// <summary>
        /// Creates a new empty instance of a <see cref="Memory"/>
        /// </summary>
        internal Memory()
        {
            this.buffer = new byte[0xFFFF];
            this.disassembler = new Disassembler();
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
        /// Loads the given ROM set in memory
        /// </summary>
        public void Load(Stream rom)
        {
            if (rom == null)
                throw new ArgumentNullException(nameof(rom));

            long initialPosition = rom.Position;

            try
            {
                using (var stream = new MemoryStream((int)(rom.Length % int.MaxValue)))
                {
                    rom.CopyTo(stream);
                    byte[] romData = stream.ToArray();
                    for (int i = 0; i < romData.Length; ++i)
                        buffer[i] = romData[i];
                }
            }
            finally
            {
                if (rom.CanSeek)
                    rom.Position = initialPosition;
            }
        }

        /// <summary>
        /// Returns the byte at the shift position, relative to the current one
        /// </summary>
        public byte GetRelative(int shift)
        {
            return this[(ushort)(ProgramCounter + shift)];
        }

        private Instruction GetCurrentInstruction()
        {
            if (buffer == null || buffer.Length == 0)
                return null;

            return disassembler.Disassemble(buffer, ProgramCounter);
        }

        #endregion
    }
}
