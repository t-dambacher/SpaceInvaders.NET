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
        /// <see cref="IExecutionContext.InstructionsCount"/>
        /// </summary>
        public int InstructionsCount => decorated.InstructionsCount;

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
        readonly private Debugger debugger;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of a <see cref="DebuggingExecutionContext"/>
        /// </summary>
        public DebuggingExecutionContext(IExecutionContext decorated)
        {
            this.decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
            this.debugger = Debugger.Instance;
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
            this.debugger.NotifyInstructionExecuted();

            HandleDebugging(instruction);
        }

        private void HandleDebugging(Instruction currentInstruction)
        {
            if (debugger.Mode.HasFlag(DebugMode.EnableLogging))
                Console.WriteLine(currentInstruction);

            HandleStateDisplaying();

            if (debugger.Mode.HasFlag(DebugMode.StepByStep))
            {
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        private void HandleStateDisplaying()
        {
            if (debugger.Mode.HasFlag(DebugMode.DisplayState))
                StateDisplayer.Display(this.decorated);
        }

        #endregion
    }
}
