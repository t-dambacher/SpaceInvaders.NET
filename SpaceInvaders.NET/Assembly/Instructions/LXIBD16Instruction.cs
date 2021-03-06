﻿using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LXIBD16Instruction : Instruction2b
    {
        internal LXIBD16Instruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.LXIBD16, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            context.Registers.C = ExtraData1;
            context.Registers.B = ExtraData2;
        }
    }
}
