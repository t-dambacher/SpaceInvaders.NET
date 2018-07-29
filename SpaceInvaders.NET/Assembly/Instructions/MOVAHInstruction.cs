using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class MOVAHInstruction : Instruction
    {
        internal MOVAHInstruction(ushort address)
            : base(address, OpCode.MOVAH)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            context.Registers.A = context.Registers.H;
        }
    }
}