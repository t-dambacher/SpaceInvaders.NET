using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LDAXDInstruction : Instruction
    {
        internal LDAXDInstruction(ushort address)
            : base(address, OpCode.LDAXD)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            ushort offset = BinaryHelper.ToAddress(processor.Registers.E, processor.Registers.D);
            processor.Registers.A = processor.Memory[offset];
        }
    }
}