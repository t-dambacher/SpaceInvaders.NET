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
        #region Properties

        public Registers Registers { get; }
        public Stack Stack { get; }
        public Memory Memory { get; }
        public Flags Flags { get; }
        public ushort ProgramCounter { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Processor"/>
        /// </summary>
        public Processor()
        {
            this.Registers = new Registers();
            this.Stack = new Stack();
            this.Flags = new Flags();
            this.Memory = new Memory();
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
                instruction.Execute(this);

                if (!addressedInstructions.TryGetValue(this.ProgramCounter, out instruction))
                    throw new AccessViolationException($"The instruction at address {this.ProgramCounter} was not found in the current instruction set.");
            }
        }

        /// <summary>
        /// Moves the position of the program counter to the given position
        /// </summary>
        public void MoveTo(ushort position)
        {
            this.ProgramCounter = position;
        }

        /// <summary>
        /// Advance the position of the program counter of the given value
        /// </summary>
        public void Advance(ushort value = 1)
        {
            this.ProgramCounter += value;
        }

        #endregion
    }
}
