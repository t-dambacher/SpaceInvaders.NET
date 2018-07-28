namespace SpaceInvaders.Processing
{
    public class State
    {
        public Registers Registers { get; }
        public ushort StackPointer { get; set; }
        public ushort ProgramCounter { get; private set; }

        public Flags Flags { get; }

        public State()
        {
            this.Registers = new Registers();
            this.Flags = new Flags();
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
    }
}
