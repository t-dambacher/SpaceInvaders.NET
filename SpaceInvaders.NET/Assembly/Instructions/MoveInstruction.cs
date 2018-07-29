using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    abstract public class MoveInstruction : Instruction
    {
        protected MoveInstruction(ushort address, OpCode opCode)
            : base(address, opCode)
        { }

        sealed override protected void ExecuteInternal(IExecutionContext context)
        {
            ushort offset = GetOffset(context.Registers);
            context.Memory[offset] = GetStoredValue(context);
        }

        abstract protected ushort GetOffset(Registers registers);
        abstract protected byte GetStoredValue(IExecutionContext context);
    }
}