using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class JNZInstruction : Instruction2b
    {
        internal JNZInstruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.JNZ, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            if (!context.Flags.Z)
                context.Memory.MoveTo(ExtraDataAddress);
            else
                context.Memory.Advance(2);
        }

        override protected void Advance(IExecutionContext context)
        { }
    }
}