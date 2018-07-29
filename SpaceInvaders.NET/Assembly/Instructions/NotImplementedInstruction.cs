using SpaceInvaders.Processing;
using System;

namespace SpaceInvaders.Assembly
{
    sealed public class NotImplementedInstruction : Instruction
    {
        public NotImplementedInstruction(ushort address, OpCode opCode)
            : base(address, opCode)
        { }

        override protected void ExecuteInternal(IExecutionContext context)
        {
            throw new NotImplementedException($"The current instruction ({OpCode} is not implemented.");   
        }
    }
}