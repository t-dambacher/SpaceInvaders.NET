namespace SpaceInvaders.Processing
{
    sealed public class Memory
    {
        readonly private byte[] buffer;

        public Memory()
        {
            this.buffer = new byte[0x2000 + 8 * 1024];   // the game has 8k of RAM and starts at 0x2000
        }

        public byte this[ushort index]
        {
            get { return this.buffer[index]; }
            set { this.buffer[index] = value; }
        }
    }
}
