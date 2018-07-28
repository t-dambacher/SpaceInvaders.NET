namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// An <see cref="Instruction"/> needing two additional bytes as parameters
    /// </summary>
    abstract public class Instruction2b : Instruction1b
    {
        #region Properties

        /// <summary>
        /// The 2nd additional byte
        /// </summary>
        protected byte ExtraData2 { get; }

        /// <summary>
        /// The address corresponding to the extradata
        /// </summary>
        protected ushort ExtraDataAddress => BinaryHelper.ToAddress(ExtraData1, ExtraData2);

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="Instruction2b"/>
        /// </summary>
        protected Instruction2b(ushort address, OpCode opCode, byte extraData1, byte extraData2)
            : base(address, opCode, extraData1)
        {
            this.ExtraData2 = extraData2;
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="object.ToString()"/>
        /// </summary>
        override public string ToString()
        {
            return Address.ToString("X4") + StringSeparator + ((ushort)OpCode).ToString("X4") + StringSeparator + OpCode.ToString() + " " + ExtraDataAddress.ToString("X4");
        }

        #endregion
    }
}
