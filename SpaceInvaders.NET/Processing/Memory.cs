using System;
using System.Collections.Generic;
using System.IO;
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
            get { return buffer[index]; }
            set { buffer[index] = value; }
        }

        /// <summary>
        /// Current instruction executing
        /// </summary>
        public Instruction Current => GetCurrentInstruction();

        #endregion

        #region Instance variables

        private byte[] buffer;
        readonly private Disassembler disassembler;

        #endregion
       
        #region Constructor

        /// <summary>
        /// Creates a new empty instance of a <see cref="Memory"/>
        /// </summary>
        internal Memory()
        {
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
                this.buffer = new byte[0xFFFF];
                using (var stream = new MemoryStream(buffer))
                {
                    rom.CopyTo(stream);
                }
            }
            finally
            {
                if (rom.CanSeek)
                    rom.Position = initialPosition;
            }
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
