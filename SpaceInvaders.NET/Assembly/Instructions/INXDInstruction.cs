using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class INXDInstruction : Instruction
    {
        internal INXDInstruction(ushort address)
           : base(address, OpCode.INXD)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.Registers.E++;
            if (processor.Registers.E == 0)
                processor.Registers.D++;
        }
    }
}
