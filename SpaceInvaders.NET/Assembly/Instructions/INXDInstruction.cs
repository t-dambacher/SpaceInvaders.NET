using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class INXDInstruction : Instruction
    {
        internal INXDInstruction(ushort address)
           : base(address, OpCode.INXD)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            context.Registers.E++;
            if (context.Registers.E == 0)
                context.Registers.D++;
        }
    }
}
