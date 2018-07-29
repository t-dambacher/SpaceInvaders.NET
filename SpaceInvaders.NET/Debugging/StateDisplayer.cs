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

                Console.Write(" af   bc   de   hl   pc   sp  flags count");

                string af = BinaryHelper.Combine(0x00, context.Registers.A).ToString("X4");
                string bc = BinaryHelper.Combine(context.Registers.C, context.Registers.B).ToString("X4");
                string de = BinaryHelper.Combine(context.Registers.E, context.Registers.D).ToString("X4");
                string hl = BinaryHelper.Combine(context.Registers.L, context.Registers.H).ToString("X4");
                string pc = context.Memory.ProgramCounter.ToString("X4");
                string sp = context.Stack.Pointer.ToString("X4");
                string flags = GetFlags(context.Flags);
                string count = context.InstructionsCount.ToString();

                Console.CursorTop = Console.WindowTop + 1;
                Console.CursorLeft = Console.WindowWidth - 44;
                Console.Write($"{af} {bc} {de} {hl} {pc} {sp} {flags} {count}");
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
                    flags.Zero ? 'Z' : '.',
                    flags.Sign ? 'S' : '.',
                    flags.Parity ? 'P' : '.',
                    flags.Carry ? 'I' : '.',
                    flags.AC ? 'A' : '.'
                }
            );
        }
    }
}
