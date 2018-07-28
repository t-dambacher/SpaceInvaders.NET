using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LXIDD16Instruction : Instruction2b
    {
        internal LXIDD16Instruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.LXIDD16, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(Processor processor)
        {
            processor.Registers.E = ExtraData1;
            processor.Registers.D = ExtraData2;
        }
    }
}
