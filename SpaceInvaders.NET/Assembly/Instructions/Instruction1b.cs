namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// An <see cref="Instruction"/> needing an additional byte as a parameter
    /// </summary>
    abstract public class Instruction1b : Instruction
    {
        #region Properties

        /// <summary>
        /// The additional byte
        /// </summary>
        protected byte ExtraData1 { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Instruction1b"/>
        /// </summary>
        protected Instruction1b(ushort address, OpCode opCode, byte extraData1)
            : base(address, opCode)
        {
            this.ExtraData1 = extraData1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        override public string ToString()
        {
            return base.ToString() + StringSeparator + ExtraData1;
        }

        #endregion
    }
}
