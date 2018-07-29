using SpaceInvaders.Processing;
using static SpaceInvaders.Assembly.BinaryHelper;

namespace SpaceInvaders.Assembly
{
    sealed public class MOVMAInstruction : MoveInstruction
    {
        internal MOVMAInstruction(ushort address)
            : base(address, OpCode.MOVMA)
        { }

        override protected ushort GetOffset(Registers registers) => Combine(registers.L, registers.H);

        override protected byte GetStoredValue(IExecutionContext context) => context.Registers.A;
    }
}