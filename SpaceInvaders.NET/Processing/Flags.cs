namespace SpaceInvaders.Processing
{
    public class Flags
    {
        public bool Z { get; set; }
        public bool S { get; set; }
        public bool P { get; set; }
        public bool CY { get; set; }
        public bool AC { get; set; }
        public byte PAD { get; set; }

        public Flags()
        {
            this.Z = true;
            this.S = true;
            this.P = true;
            this.CY = false;
            this.AC = true;
        }
    }
}
