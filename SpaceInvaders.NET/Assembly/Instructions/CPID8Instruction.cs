using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class CPID8Instruction : Instruction1b
    {
        internal CPID8Instruction(ushort address, byte extraData1)
            : base(address, OpCode.CPID8, extraData1)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            byte x = (byte)(context.Registers.A - ExtraData1);
            context.Flags.Zero = x == 0;
            context.Flags.Sign = (x & 0x80) == 0x80;
            context.Flags.Parity = BinaryHelper.IsPair(x);
            context.Flags.Carry = context.Registers.A < ExtraData1;
        }
    }
}
