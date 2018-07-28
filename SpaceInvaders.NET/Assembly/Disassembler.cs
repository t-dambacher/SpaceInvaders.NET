using SpaceInvaders.Assembly;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// Disassembler able to read the content of a ROM file
    /// </summary>
    sealed public class Disassembler
    {
        #region Instance variables

        readonly private Stream rom;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Disassembler"/> to disassemble the input rom file
        /// </summary>
        public Disassembler(Stream rom)
        {
            this.rom = rom ?? throw new ArgumentNullException(nameof(rom));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs the disassembler to get a list of instruction that could be executed
        /// </summary>
        public IEnumerable<Instruction> Disassemble()
        {
            long initialPosition = rom.Position;

            if (rom.CanSeek)
                rom.Position = 0;

            try
            {
                using (BinaryReader reader = new BinaryReader(this.rom))
                {
                    ushort currentAddress = 0;

                    // Checking for EOF
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        // Parsing the OpCode and its extra data
                        byte value = reader.ReadByte();
                        
                        OpCode opCode = OpCodes.FromHex(value);
                        ushort size = Instruction.GetExtraDataSize(opCode);
                        byte[] data = new byte[0];

                        if (size > 0)
                        { 
                            data = reader.ReadBytes(size);
                        }

                        yield return Instruction.FromOpCode(currentAddress, opCode, data);
                        currentAddress += (ushort)(1 + size);

                    }
                }
            }
            finally
            {
                if (rom.CanSeek)
                    rom.Position = initialPosition;
            }
        }

        #endregion
    }
}
