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
        #region Constructor

        /// <summary>
        /// Creates a new <see cref="Disassembler"/> 
        /// </summary>
        public Disassembler()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs the disassembler to get a list of instruction that could be executed
        /// </summary>
        public IEnumerable<Instruction> Disassemble(Stream rom)
        {
            if (rom == null)
                throw new ArgumentNullException(nameof(rom));

            long initialPosition = rom.Position;

            if (rom.CanSeek)
                rom.Position = 0;

            try
            {
                using (BinaryReader reader = new BinaryReader(rom))
                {
                    ushort currentAddress = 0;

                    // Checking for EOF
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        // Parsing the OpCode and its extra data
                        (Instruction instruction, ushort size) = DisassembleInternal(
                            reader.ReadByte(),
                            count => reader.ReadBytes(count),
                            currentAddress
                        );

                        yield return instruction;
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

        /// <summary>
        /// Runs the disassembler on the given buffer to get the current instruction
        /// </summary>
        public Instruction Disassemble(byte[] buffer, ushort offset)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            byte[] bufferReader(ushort count)
            {
                // no checks are made here, it is not our responsability if the memory is invalid
                byte[] result = new byte[count];
                for (int i = 0; i < count; ++i)
                    result[i] = buffer[offset + i + 1]; // the first byte has already been read, it is the OpCode (buffer[offset])
                return result;
            }

            (Instruction instruction, ushort size) = DisassembleInternal(
                buffer[offset],
                bufferReader,
                offset
            );

            return instruction;
        }

        private (Instruction, ushort) DisassembleInternal(byte value, Func<ushort, byte[]> reader, ushort address)
        {
            OpCode opCode = OpCodes.FromHex(value);
            ushort size = Instruction.GetExtraDataSize(opCode);
            byte[] data = new byte[0];

            if (size > 0)
            {
                data = reader(size);
            }

            return (Instruction.FromOpCode(address, opCode, data), size);
        }

        #endregion
    }
}
