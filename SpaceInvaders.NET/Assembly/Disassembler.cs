﻿using System;
using System.IO;

namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// Disassembler able to read the content of a ROM file
    /// </summary>
    sealed public class Disassembler
    {
        readonly private Stream rom;

        /// <summary>
        /// Creates a new <see cref="Disassembler"/> to disassemble the input rom file
        /// </summary>
        public Disassembler(Stream rom)
        {
            this.rom = rom ?? throw new ArgumentNullException(nameof(rom));
        }

        /// <summary>
        /// Runs the disassembler
        /// </summary>
        public void Run()
        {
            long initialPosition = rom.Position;

            if (rom.CanSeek)
                rom.Position = 0;

            try
            {
                using (BinaryReader reader = new BinaryReader(this.rom))
                {
                    // Checking for EOF
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        byte value = reader.ReadByte();
                        OpCode opCode = OpCodes.Parse(value);

                        if (opCode.Size > 1)
                            reader.ReadBytes(opCode.Size - 1);

                        Console.WriteLine(opCode);

                    }
                }
            }
            finally
            {
                if (rom.CanSeek)
                    rom.Position = initialPosition;
            }
        }
    }
}