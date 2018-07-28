using SpaceInvaders.Assembly;
using System;
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

                var fileInfo = new FileInfo(args[0]);
                if (!fileInfo.Exists)
                    throw new ArgumentException("The rom path is invalid.");

                using (Stream rom = fileInfo.OpenRead())
                {
                    var dissassembler = new Disassembler(rom);
                    dissassembler.Run();
                    Console.ReadKey();
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
