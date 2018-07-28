using NativeStack = System.Collections.Generic.Stack<byte>;

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

        #region Instance variables

        readonly private NativeStack stack;

        #endregion

        /// <summary>
        /// Creates a new empty instance of a <see cref="Stack"/>
        /// </summary>
        public Stack()
        {
            this.stack = new NativeStack();
        }

        /// <summary>
        /// Pushes a byte on the stack
        /// </summary>
        public void Push(byte data)
        {
            this.stack.Push(data);
            this.Pointer -= 1;
        }

        /// <summary>
        /// Moves the position of the stack pointer to the given position
        /// </summary>
        public void MoveTo(ushort position)
        {
            this.Pointer = position;
        }
    }
}
