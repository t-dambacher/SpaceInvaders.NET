using SpaceInvaders.Assembly;
using SpaceInvaders.Processing;
using System;

namespace SpaceInvaders.Debugging
{
    /// <summary>
    /// Decorator of a <see cref="IExecutionContext"/> to add debugging capabilities
    /// </summary>
    sealed internal class DebuggingExecutionContext : IExecutionContext
    {
        #region Properties

        /// <summary>
        /// <see cref="IExecutionContext.Cycles"/>
        /// </summary>
        public int Cycles => decorated.Cycles;

        /// <summary>
        /// <see cref="IExecutionContext.Flags"/>
        /// </summary>
        public Flags Flags => decorated.Flags;
        
        /// <summary>
        /// <see cref="IExecutionContext.Memory"/>
        /// </summary>
        public Memory Memory => decorated.Memory;

        /// <summary>
        /// <see cref="IExecutionContext.Registers"/>
        /// </summary>
        public Registers Registers => decorated.Registers;

        /// <summary>
        /// <see cref="IExecutionContext.Stack"/>
        /// </summary>
        public Stack Stack => decorated.Stack;

        #endregion

        #region Instance variables

        readonly private IExecutionContext decorated;
        readonly private DebugMode mode;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a <see cref="DebuggingExecutionContext"/>
        /// </summary>
        public DebuggingExecutionContext(IExecutionContext decorated, DebugMode mode)
        {
            this.decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
            this.mode = mode;
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IExecutionContext.Execute(Instruction)"/>
        /// </summary>
        public void Execute(Instruction instruction)
        {
            HandleStateDisplaying();

            this.decorated.Execute(instruction);

            HandleDebugging(instruction);
        }


        private void HandleDebugging(Instruction currentInstruction)
        {
            if (this.mode.HasFlag(DebugMode.EnableLogging))
                Console.WriteLine(currentInstruction);

            HandleStateDisplaying();

            if (this.mode.HasFlag(DebugMode.StepByStep))
            {
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        private void HandleStateDisplaying()
        {
            if (this.mode.HasFlag(DebugMode.DisplayState))
                StateDisplayer.Display(this.decorated);
        }

        #endregion
    }
}
