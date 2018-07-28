using SpaceInvaders.Assembly;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceInvaders.Processing
{
    /// <summary>
    /// The 8080 processor
    /// </summary>
    sealed public class Processor
    {
        #region Instance variables

        readonly private State state;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Processor"/>
        /// </summary>
        public Processor()
        {
            state = new State();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Executes the given instruction set
        /// </summary>
        public void Execute(IEnumerable<Instruction> instructions)
        {
            if (instructions == null)
                throw new ArgumentNullException(nameof(instructions));
            
            IReadOnlyDictionary<ushort, Instruction> addressedInstructions = instructions.OrderBy(i => i.Address).ToDictionary(i => i.Address);
            Instruction instruction = addressedInstructions.Values.FirstOrDefault();

            while (instruction != null)
            {
                instruction.Execute(this.state);

                if (!addressedInstructions.TryGetValue(this.state.ProgramCounter, out instruction))
                    throw new AccessViolationException($"The instruction at address {this.state.ProgramCounter} was not found in the current instruction set.");
            }
        }

        #endregion
    }
}
