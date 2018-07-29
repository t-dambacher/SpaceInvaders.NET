using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class MVIMD8Instruction : Instruction1b
    {
        internal MVIMD8Instruction(ushort address, byte extraData1)
            : base(address, OpCode.MVIMD8, extraData1)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            // AC set if lower nibble of h was zero prior to dec
            ushort offset = BinaryHelper.Combine(context.Registers.L, context.Registers.H);
            context.Memory[offset] = ExtraData1;
        }
    }
}
