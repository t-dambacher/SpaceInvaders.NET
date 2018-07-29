using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class INXHInstruction : Instruction
    {
        internal INXHInstruction(ushort address)
           : base(address, OpCode.INXH)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            context.Registers.L++;
            if (context.Registers.L == 0)
                context.Registers.H++;
        }
    }
}
