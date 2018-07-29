using SpaceInvaders.Debugging;
using SpaceInvaders.Parsing;
using SpaceInvaders.Processing;
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

                Console.CursorVisible = false;

                using (Stream rom = RomReader.Read(args[0]))
                {
                    Processor processor = Processor.Create();
                    Debugger.Instance.Mode = DebugMode.DisplayState | DebugMode.EnableLogging;
                    processor.Execute(rom);
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
