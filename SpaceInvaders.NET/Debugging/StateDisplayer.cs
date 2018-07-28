using SpaceInvaders.Assembly;
using SpaceInvaders.Processing;
using System;

namespace SpaceInvaders.Debugging
{
    static internal class StateDisplayer
    {
        static public void Display(Processor processor)
        {
            if (processor == null)
                throw new ArgumentNullException(nameof(processor));

            int originalLeft = Console.CursorLeft;
            int originalTop = Console.CursorTop;

            try
            {

                Console.CursorTop = Console.WindowTop;
                Console.CursorLeft = Console.WindowWidth - 44; // 44 is the max length of the debug string. it is large enough so that we never have to get to this limit.

                Console.Write(" af   bc   de   hl   pc   sp  flags cycles");

                string af = BinaryHelper.ToAddress(0x00, processor.Registers.A).ToString("X4");
                string bc = BinaryHelper.ToAddress(processor.Registers.C, processor.Registers.B).ToString("X4");
                string de = BinaryHelper.ToAddress(processor.Registers.E, processor.Registers.D).ToString("X4");
                string hl = BinaryHelper.ToAddress(processor.Registers.L, processor.Registers.H).ToString("X4");
                string pc = processor.ProgramCounter.ToString("X4");
                string sp = processor.Stack.Pointer.ToString("X4");
                string flags = GetFlags(processor.Flags);
                string cycles = processor.Cycle.ToString();

                Console.CursorTop = Console.WindowTop + 1;
                Console.CursorLeft = Console.WindowWidth - 44;
                Console.Write($"{af} {bc} {de} {hl} {pc} {sp} {flags} {cycles}");
            }
            finally
            {
                Console.CursorLeft = originalLeft;
                Console.CursorTop = originalTop;
            }
        }

        static private string GetFlags(Flags flags)
        {
            return new string(
                new[] {
                    flags.Z ? 'Z' : '.',
                    flags.S ? 'S' : '.',
                    flags.P ? 'P' : '.',
                    flags.CY ? 'I' : '.',
                    flags.AC ? 'A' : '.'
                }
            );
        }
    }
}
