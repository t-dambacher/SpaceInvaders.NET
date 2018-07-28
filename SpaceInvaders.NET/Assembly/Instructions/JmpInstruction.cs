using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class JmpInstruction : Instruction2b
    {
        internal JmpInstruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.JMP, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.MoveTo(ExtraDataAddress);
        }

        override protected void Advance(Processor processor)
        { }
    }
}