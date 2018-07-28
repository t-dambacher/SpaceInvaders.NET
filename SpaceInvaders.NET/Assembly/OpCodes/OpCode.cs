namespace SpaceInvaders.Assembly
{
    sealed public class OpCode
    {
        public byte Value { get; }

        public string Instruction { get; }

        public int Size { get; }

        public OpCode(byte value, string instruction, int size = 1)
        {
            this.Value = value;
            this.Instruction = instruction;
            this.Size = size;
        }

        override public string ToString()
        {
            return Instruction;
        }
    }
}
