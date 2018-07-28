using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class DCRBInstruction : Instruction
    {
        internal DCRBInstruction(ushort address)
           : base(address, OpCode.DCRB)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            byte res = (byte)(processor.Registers.B - 1);
            processor.Flags.Z = res == 0;
            processor.Flags.S = (0x80 == (res & 0x80));
            processor.Flags.P = BinaryHelper.Parity(res, 8);
            processor.Registers.B = res;
        }
    }
}
