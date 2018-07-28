using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class MVIBD8Instruction : Instruction1b
    {
        internal MVIBD8Instruction(ushort address, byte extraData1)
            : base(address, OpCode.MVIBD8, extraData1)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.Registers.B = ExtraData1;
        }
    }
}
