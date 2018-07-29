namespace SpaceInvaders.Processing
{
    /// <summary>
    /// The stack used by the 8080 processor
    /// </summary>
    public class Stack
    {
        #region Properties

        /// <summary>
        /// The pointer to the top of the stack
        /// </summary>
        public ushort Pointer { get; private set; }

        #endregion

        #region Instance variable

        readonly private Memory memory;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new empty instance of a <see cref="Stack"/>
        /// </summary>
        internal Stack(Memory memory)
        {
            this.memory = memory;
            this.Pointer = 0xF000;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Pushes a byte on the stack
        /// </summary>
        public void Push(byte data)
        {
            this.memory[Pointer] = data;
            this.Pointer -= 1;
        }

        /// <summary>
        /// Moves the position of the stack pointer to the given position
        /// </summary>
        public void MoveTo(ushort position)
        {
            this.Pointer = position;
        }

        #endregion
    }
}
