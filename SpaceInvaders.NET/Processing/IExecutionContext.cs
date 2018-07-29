using SpaceInvaders.Assembly;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// Interface of the 8080 processor's execution context
    /// </summary>
    public interface IExecutionContext
    {
        /// <summary>
        /// The processor's registers
        /// </summary>
        Registers Registers { get; }

        /// <summary>
        /// The processor's stack
        /// </summary>
        Stack Stack { get; }

        /// <summary>
        /// The processor's memory
        /// </summary>
        Memory Memory { get; }

        /// <summary>
        /// The processor's flags, updated after binary operations
        /// </summary>
        Flags Flags { get; }

        /// <summary>
        /// The current number of instructions that has been executed
        /// </summary>
        int InstructionsCount { get; }

        /// <summary>
        /// Executes the given instruction
        /// </summary>
        void Execute(Instruction instruction);

    }
}