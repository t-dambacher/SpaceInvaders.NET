using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class INXHInstruction : Instruction
    {
        internal INXHInstruction(ushort address)
           : base(address, OpCode.INXH)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.Registers.L++;
            if (processor.Registers.L == 0)
                processor.Registers.H++;
        }
    }
}
