﻿using SpaceInvaders.Processing;

namespace SpaceInvaders.Assembly
{
    sealed public class LXIHD16Instruction : Instruction2b
    {
        internal LXIHD16Instruction(ushort address, byte extraData1, byte extraData2)
            : base(address, OpCode.LXIHD16, extraData1, extraData2)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            context.Registers.L = ExtraData1;
            context.Registers.H = ExtraData2;
        }
    }
}
