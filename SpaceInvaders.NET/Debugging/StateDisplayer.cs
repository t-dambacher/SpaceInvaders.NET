using SpaceInvaders.Assembly;
using SpaceInvaders.Processing;
using System;

namespace SpaceInvaders.Debugging
{
    /// <summary>
    /// Helper to display debug informations on the screen
    /// </summary>
    static internal class StateDisplayer
    {
        /// <summary>
        /// Displays informations on the screen about the current execution context
        /// </summary>
        static public void Display(IExecutionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            int originalLeft = Console.CursorLeft;
            int originalTop = Console.CursorTop;

            try
            {

                Console.CursorTop = Console.WindowTop;
                Console.CursorLeft = Console.WindowWidth - 44; // 44 is the max length of the debug string. it is large enough so that we never have to get to this limit.

                Console.Write(" af   bc   de   hl   pc   sp  flags cycles");

                string af = BinaryHelper.ToAddress(0x00, context.Registers.A).ToString("X4");
                string bc = BinaryHelper.ToAddress(context.Registers.C, context.Registers.B).ToString("X4");
                string de = BinaryHelper.ToAddress(context.Registers.E, context.Registers.D).ToString("X4");
                string hl = BinaryHelper.ToAddress(context.Registers.L, context.Registers.H).ToString("X4");
                string pc = context.Memory.ProgramCounter.ToString("X4");
                string sp = context.Stack.Pointer.ToString("X4");
                string flags = GetFlags(context.Flags);
                string cycles = context.Cycles.ToString();

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
