using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class CallInstruction : Instruction2b
    {
        internal CallInstruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.CALL, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            short ret = (short)(processor.ProgramCounter + 2);

            processor.Stack.Push((byte)((ret >> 8) & 0xFF));
            processor.Stack.Push((byte)(ret & 0xff));

            processor.MoveTo(ExtraDataAddress);
        }

        override protected void Advance(Processor processor)
        { }
    }
}
