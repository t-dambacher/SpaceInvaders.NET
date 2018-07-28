using SpaceInvaders.Assembly;
using SpaceInvaders.Debugging;
using SpaceInvaders.Parsing;
using SpaceInvaders.Processing;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpaceInvaders
{
    /// <summary>
    /// Application's entry point
    /// </summary>
    static public class Program
    {
        /// <summary>
        /// Main entry point
        /// </summary>
        /// <param name="args">Command line parameters</param>
        static public void Main(string[] args)
        {
            try
            {
                if (args?.Length != 1)
                    throw new ArgumentException("Usage: spaceinvaders <rom path>");

                DebugMode debugMode = DebugMode.None;
#if DEBUG
                debugMode = DebugMode.All;
#endif

                using (Stream rom = RomReader.Read(args[0]))
                {
                    var dissassembler = new Disassembler(rom);
                    var processor = new Processor(debugMode);

                    IEnumerable<Instruction> instructions = dissassembler.Disassemble();
                    processor.Execute(instructions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
