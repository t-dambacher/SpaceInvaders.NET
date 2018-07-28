using System.Collections.Generic;
using System;

namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// Represents an 8080's OpCode
    /// </summary>
    static public class OpCodes
    {
        /// <summary>
        /// Parses a given <see cref="ushort"/> raw opCode and translates it into an <see cref="OpCode"/>
        /// </summary>
        static public OpCode FromHex(ushort opCode)
        {
            OpCode result = (OpCode)opCode;
            if (!Enum.IsDefined(typeof(OpCode), result))
                throw new ArgumentException($"The {opCode.ToString("X4")} is unknown.", nameof(opCode));

            return result;
        }
    }
}
