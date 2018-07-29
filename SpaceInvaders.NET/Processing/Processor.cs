using SpaceInvaders.Assembly;
using SpaceInvaders.Debugging;
using System;
using System.IO;
using System.Threading;

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

        /// <summary>
        /// The screen
        /// </summary>
        public Screen Screen { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Processor"/>
        /// </summary>
        private Processor(IExecutionContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.Screen = new Screen(Context.Memory);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads in memory the given ROM and starts executing it
        /// </summary>
        public void Execute(Stream rom)
        {
            if (rom == null)
                throw new ArgumentNullException(nameof(rom));

            Context.Memory.Load(rom);

            Instruction instruction = Context.Memory.CurrentInstruction;

            while (instruction != null)
            {
                Context.Execute(instruction);
                instruction = Context.Memory.CurrentInstruction;
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Creates a new <see cref="IProcessor"/> with the given debugging capabilities.
        /// </summary>
        static public Processor Create()
        {
            IExecutionContext context = new ExecutionContext();
#if DEBUG
            context = new DebuggingExecutionContext(context);
#endif
            return new Processor(context);
        }

        #endregion
    }
}
