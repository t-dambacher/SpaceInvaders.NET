using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    abstract public class MoveInstruction : Instruction
    {
        protected MoveInstruction(ushort address, OpCode opCode)
            : base(address, opCode)
        { }

        sealed override protected void ExecuteInternal(Processor processor)
        {
            ushort offset = GetOffset(processor.Registers);
            processor.Memory[offset] = GetStoredValue(processor);
        }

        abstract protected ushort GetOffset(Registers registers);
        abstract protected byte GetStoredValue(Processor processor);
    }
}