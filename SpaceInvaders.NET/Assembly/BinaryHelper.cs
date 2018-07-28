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
        static public ushort ToAddress(byte extraData1, byte extraData2)
        {
            return (ushort)((extraData2 << 8) | extraData1);
        }

        static public bool Parity(byte value, int size)
        {
            int i;
            int p = 0;
            value = (byte)(value & ((1 << size) - 1));
            for (i = 0; i < size; i++)
            {
                if ((value & 0x1) != 0x00)
                    p++;
                value = (byte)(value >> 1);
            }
            return (0 == (p & 0x1));
        }
    }
}
