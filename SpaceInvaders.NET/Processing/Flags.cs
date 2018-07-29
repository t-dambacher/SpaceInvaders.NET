namespace SpaceInvaders.Processing
{
    public class Flags
    {
        public bool Zero { get; set; }
        public bool Sign { get; set; }
        public bool Parity { get; set; }
        public bool Carry { get; set; }
        public bool AC { get; set; }
        public byte PAD { get; set; }

        public Flags()
        {
            this.Zero = false;
            this.Sign = false;
            this.Parity = false;
            this.Carry = false;
            this.AC = false;
        }
    }
}
