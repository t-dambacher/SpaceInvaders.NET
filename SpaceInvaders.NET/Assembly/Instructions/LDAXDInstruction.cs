using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LDAXDInstruction : Instruction
    {
        internal LDAXDInstruction(ushort address)
            : base(address, OpCode.LDAXD)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            ushort offset = BinaryHelper.ToAddress(context.Registers.E, context.Registers.D);
            context.Registers.A = context.Memory[offset];
        }
    }
}