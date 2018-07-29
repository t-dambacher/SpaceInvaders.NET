using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class CallInstruction : Instruction2b
    {
        internal CallInstruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.CALL, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            short ret = (short)(context.Memory.ProgramCounter + 2);

            context.Stack.Push((byte)((ret >> 8) & 0xFF));
            context.Stack.Push((byte)(ret & 0xff));

            context.Memory.MoveTo(ExtraDataAddress);
        }

        override protected void Advance(IExecutionContext context)
        { }
    }
}
