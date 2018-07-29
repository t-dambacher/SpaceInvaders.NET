using SpaceInvaders.Assembly;
using SpaceInvaders.Debugging;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// The 8080 processor
    /// </summary>
    sealed public class Processor
    {
        #region Properties

        /// <summary>
        /// Execution context
        /// </summary>
        public IExecutionContext Context { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Processor"/>
        /// </summary>
        private Processor(IExecutionContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes a set of instructions
        /// </summary>
        public void Execute(IEnumerable<Instruction> instructions)
        {
            if (instructions == null)
                throw new ArgumentNullException(nameof(instructions));

            Context.Memory.Load(instructions);

            while (Context.Memory.Current != null)
            {
                Context.Execute(Context.Memory.Current);
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates a new <see cref="IProcessor"/> with the given debugging capabilities.
        /// </summary>
        static public Processor Create(DebugMode mode)
        {
            IExecutionContext context = new ExecutionContext();

            if (mode != DebugMode.None)
                context = new DebuggingExecutionContext(context, mode);

            return new Processor(context);
        }

        #endregion
    }
}
