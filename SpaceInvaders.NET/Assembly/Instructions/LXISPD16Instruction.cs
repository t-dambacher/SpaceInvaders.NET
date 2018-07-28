using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LXISPD16Instruction : Instruction2b
    {
        internal LXISPD16Instruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.LXISPD16, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.Stack.MoveTo(ExtraDataAddress);
        }
    }
}
