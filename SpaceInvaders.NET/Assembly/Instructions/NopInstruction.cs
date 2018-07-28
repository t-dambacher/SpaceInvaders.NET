using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class NopInstruction : Instruction
    {
        internal NopInstruction(ushort address)
            : base(address, OpCode.NOP)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            // No-op
        }
    }
}
