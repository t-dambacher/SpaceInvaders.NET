using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class RETInstruction : Instruction
    {
        internal RETInstruction(ushort address)
            : base(address, OpCode.RET)
        {
            Debugger.Pause();
        }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            byte first = context.Stack.Pop();
            byte second = context.Stack.Pop();

            ushort destination = BinaryHelper.Combine(first, second);
            context.Memory.MoveTo(destination);
        }

        override protected void Advance(IExecutionContext context)
        { }
    }
}