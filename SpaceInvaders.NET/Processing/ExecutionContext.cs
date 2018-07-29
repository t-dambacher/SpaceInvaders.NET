using SpaceInvaders.Assembly;
using System;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// Default implementation of the <see cref="IExecutionContext"/>
    /// </summary>
    sealed internal class ExecutionContext : IExecutionContext
    {
        /// <summary>
        /// <see cref="IExecutionContext.Registers"/>
        /// </summary>
        public Registers Registers { get; }

        /// <summary>
        /// <see cref="IExecutionContext.Stack"/>
        /// </summary>

        public Stack Stack { get; }

        /// <summary>
        /// <see cref="IExecutionContext.Memory"/>
        /// </summary>
        public Memory Memory { get; }

        /// <summary>
        /// <see cref="IExecutionContext.Flags"/>
        /// </summary>
        public Flags Flags { get; }

        /// <summary>
        /// <see cref="IExecutionContext.Cycles"/>
        /// </summary>
        public int Cycles { get; private set; }

        #region Constructor

        /// <summary>
        /// Creates a new empty instance of a <see cref="ExecutionContext"/>
        /// </summary>
        internal ExecutionContext()
        {
            this.Registers = new Registers();
            this.Stack = new Stack();
            this.Flags = new Flags();
            this.Memory = new Memory();
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="IExecutionContext.Execute(Instruction)"/>
        /// </summary>
        public void Execute(Instruction instruction)
        {
            if (instruction == null)
                throw new ArgumentNullException(nameof(instruction));

            instruction.Execute(this);

            Cycles += 4;
        }

        #endregion
    }
}
