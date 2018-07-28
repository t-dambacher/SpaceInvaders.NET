using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class JNZInstruction : Instruction2b
    {
        internal JNZInstruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.JNZ, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            if (!processor.Flags.Z)
                processor.MoveTo(ExtraDataAddress);
            else
                processor.Advance(2);
        }

        override protected void Advance(Processor processor)
        { }
    }
}