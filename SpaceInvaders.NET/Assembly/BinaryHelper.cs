namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// Helper for binary computing
    /// </summary>
    static internal class BinaryHelper
    {
        /// <summary>
        /// Converts two bytes to a short, for addressing purposes
        /// </summary>
        static public ushort Combine(byte extraData1, byte extraData2)
        {
            return (ushort)((extraData2 << 8) | extraData1);
        }

        static public bool IsPair(byte value)
        {
            return (value & 0x01) == 0x00;
        }
    }
}
