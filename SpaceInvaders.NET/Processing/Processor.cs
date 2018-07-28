using SpaceInvaders.Assembly;
using SpaceInvaders.Debugging;
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
        public int Cycle { get; private set; }

        #endregion

        #region Instance variables

        readonly private DebugMode debugMode;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Processor"/>
        /// </summary>
        public Processor(DebugMode debugMode = DebugMode.None)
        {
            this.Registers = new Registers();
            this.Stack = new Stack();
            this.Flags = new Flags();
            this.Memory = new Memory();
            this.debugMode = debugMode;
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
                HandleStateDisplaying();

                instruction.Execute(this);

                Cycle += 4;

                HandleDebugging(instruction);

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

        private void HandleDebugging(Instruction currentInstruction)
        {
            if (debugMode.HasFlag(DebugMode.EnableLogging))
                Console.WriteLine(currentInstruction);

            HandleStateDisplaying();

            if (debugMode.HasFlag(DebugMode.StepByStep))
            {
                Console.ReadKey();
                Console.SetCursorPosition(0, Console.CursorTop);
            }
        }

        private void HandleStateDisplaying()
        {
            if(debugMode.HasFlag(DebugMode.DisplayState))
                    StateDisplayer.Display(this);
        }

        #endregion
    }
}
