using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class DCRBInstruction : Instruction
    {
        internal DCRBInstruction(ushort address)
           : base(address, OpCode.DCRB)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            byte res = (byte)(context.Registers.B - 1);
            context.Flags.Z = res == 0;
            context.Flags.S = (0x80 == (res & 0x80));
            context.Flags.P = BinaryHelper.IsPair(res);
            context.Registers.B = res;
        }
    }
}
