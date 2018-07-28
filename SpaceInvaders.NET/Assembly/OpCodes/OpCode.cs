using System.Collections.Generic;
using System.Linq;

namespace SpaceInvaders.Assembly
{
    /// <summary>
    /// Represents an 8080's OpCode
    /// </summary>
    sealed public class OpCode
    {
        #region Static fields

        /// <summary>
        /// All existing <see cref="OpCode"/>
        /// </summary>
        static private IReadOnlyDictionary<byte, OpCode> codes = new[] {
            new OpCode(0x00, "NOP"),
            new OpCode(0x01, "LXI B,D16", 3),
            new OpCode(0x02, "STAX B"),
            new OpCode(0x03, "INX B"),
            new OpCode(0x04, "INR B"),
            new OpCode(0x05, "DCR B"),
            new OpCode(0x06, "MVI B, D8", 2),
            new OpCode(0x07, "RLC"),
            new OpCode(0x08, "-"),
            new OpCode(0x09, "DAD B"),
            new OpCode(0x0a, "LDAX B"),
            new OpCode(0x0b, "DCX B"),
            new OpCode(0x0c, "INR C"),
            new OpCode(0x0d, "DCR C"),
            new OpCode(0x0e, "MVI C,D8", 2),
            new OpCode(0x0f, "RRC"),
            new OpCode(0x10, "-"),
            new OpCode(0x11, "LXI D,D16", 3),
            new OpCode(0x12, "STAX D"),
            new OpCode(0x13, "INX D"),
            new OpCode(0x14, "INR D"),
            new OpCode(0x15, "DCR D"),
            new OpCode(0x16, "MVI D, D8", 2),
            new OpCode(0x17, "RAL"),
            new OpCode(0x18, "-"),
            new OpCode(0x19, "DAD D"),
            new OpCode(0x1a, "LDAX D"),
            new OpCode(0x1b, "DCX D"),
            new OpCode(0x1c, "INR E"),
            new OpCode(0x1d, "DCR E"),
            new OpCode(0x1e, "MVI E,D8", 2),
            new OpCode(0x1f, "RAR"),
            new OpCode(0x20, "RIM"),
            new OpCode(0x21, "LXI H,D16", 3),
            new OpCode(0x22, "SHLD adr", 3),
            new OpCode(0x23, "INX H"),
            new OpCode(0x24, "INR H"),
            new OpCode(0x25, "DCR H"),
            new OpCode(0x26, "MVI H,D8", 2),
            new OpCode(0x27, "DAA"),
            new OpCode(0x28, "-"),
            new OpCode(0x29, "DAD H"),
            new OpCode(0x2a, "LHLD adr", 3),
            new OpCode(0x2b, "DCX H"),
            new OpCode(0x2c, "INR L"),
            new OpCode(0x2d, "DCR L"),
            new OpCode(0x2e, "MVI L, D8", 2),
            new OpCode(0x2f, "CMA"),
            new OpCode(0x30, "SIM"),
            new OpCode(0x31, "LXI SP, D16", 3),
            new OpCode(0x32, "STA adr", 3),
            new OpCode(0x33, "INX SP"),
            new OpCode(0x34, "INR M"),
            new OpCode(0x35, "DCR M"),
            new OpCode(0x36, "MVI M,D8", 2),
            new OpCode(0x37, "STC"),
            new OpCode(0x38, "-"),
            new OpCode(0x39, "DAD SP"),
            new OpCode(0x3a, "LDA adr", 3),
            new OpCode(0x3b, "DCX SP"),
            new OpCode(0x3c, "INR A"),
            new OpCode(0x3d, "DCR A"),
            new OpCode(0x3e, "MVI A,D8", 2),
            new OpCode(0x3f, "CMC"),
            new OpCode(0x40, "MOV B,B"),
            new OpCode(0x41, "MOV B,C"),
            new OpCode(0x42, "MOV B,D"),
            new OpCode(0x43, "MOV B,E"),
            new OpCode(0x44, "MOV B,H"),
            new OpCode(0x45, "MOV B,L"),
            new OpCode(0x46, "MOV B,M"),
            new OpCode(0x47, "MOV B,A"),
            new OpCode(0x48, "MOV C,B"),
            new OpCode(0x49, "MOV C,C"),
            new OpCode(0x4a, "MOV C,D"),
            new OpCode(0x4b, "MOV C,E"),
            new OpCode(0x4c, "MOV C,H"),
            new OpCode(0x4d, "MOV C,L"),
            new OpCode(0x4e, "MOV C,M"),
            new OpCode(0x4f, "MOV C,A"),
            new OpCode(0x50, "MOV D,B"),
            new OpCode(0x51, "MOV D,C"),
            new OpCode(0x52, "MOV D,D"),
            new OpCode(0x53, "MOV D,E"),
            new OpCode(0x54, "MOV D,H"),
            new OpCode(0x55, "MOV D,L"),
            new OpCode(0x56, "MOV D,M"),
            new OpCode(0x57, "MOV D,A"),
            new OpCode(0x58, "MOV E,B"),
            new OpCode(0x59, "MOV E,C"),
            new OpCode(0x5a, "MOV E,D"),
            new OpCode(0x5b, "MOV E,E"),
            new OpCode(0x5c, "MOV E,H"),
            new OpCode(0x5d, "MOV E,L"),
            new OpCode(0x5e, "MOV E,M"),
            new OpCode(0x5f, "MOV E,A"),
            new OpCode(0x60, "MOV H,B"),
            new OpCode(0x61, "MOV H,C"),
            new OpCode(0x62, "MOV H,D"),
            new OpCode(0x63, "MOV H,E"),
            new OpCode(0x64, "MOV H,H"),
            new OpCode(0x65, "MOV H,L"),
            new OpCode(0x66, "MOV H,M"),
            new OpCode(0x67, "MOV H,A"),
            new OpCode(0x68, "MOV L,B"),
            new OpCode(0x69, "MOV L,C"),
            new OpCode(0x6a, "MOV L,D"),
            new OpCode(0x6b, "MOV L,E"),
            new OpCode(0x6c, "MOV L,H"),
            new OpCode(0x6d, "MOV L,L"),
            new OpCode(0x6e, "MOV L,M"),
            new OpCode(0x6f, "MOV L,A"),
            new OpCode(0x70, "MOV M,B"),
            new OpCode(0x71, "MOV M,C"),
            new OpCode(0x72, "MOV M,D"),
            new OpCode(0x73, "MOV M,E"),
            new OpCode(0x74, "MOV M,H"),
            new OpCode(0x75, "MOV M,L"),
            new OpCode(0x76, "HLT"),
            new OpCode(0x77, "MOV M,A"),
            new OpCode(0x78, "MOV A,B"),
            new OpCode(0x79, "MOV A,C"),
            new OpCode(0x7a, "MOV A,D"),
            new OpCode(0x7b, "MOV A,E"),
            new OpCode(0x7c, "MOV A,H"),
            new OpCode(0x7d, "MOV A,L"),
            new OpCode(0x7e, "MOV A,M"),
            new OpCode(0x7f, "MOV A,A"),
            new OpCode(0x80, "ADD B"),
            new OpCode(0x81, "ADD C"),
            new OpCode(0x82, "ADD D"),
            new OpCode(0x83, "ADD E"),
            new OpCode(0x84, "ADD H"),
            new OpCode(0x85, "ADD L"),
            new OpCode(0x86, "ADD M"),
            new OpCode(0x87, "ADD A"),
            new OpCode(0x88, "ADC B"),
            new OpCode(0x89, "ADC C"),
            new OpCode(0x8a, "ADC D"),
            new OpCode(0x8b, "ADC E"),
            new OpCode(0x8c, "ADC H"),
            new OpCode(0x8d, "ADC L"),
            new OpCode(0x8e, "ADC M"),
            new OpCode(0x8f, "ADC A"),
            new OpCode(0x90, "SUB B"),
            new OpCode(0x91, "SUB C"),
            new OpCode(0x92, "SUB D"),
            new OpCode(0x93, "SUB E"),
            new OpCode(0x94, "SUB H"),
            new OpCode(0x95, "SUB L"),
            new OpCode(0x96, "SUB M"),
            new OpCode(0x97, "SUB A"),
            new OpCode(0x98, "SBB B"),
            new OpCode(0x99, "SBB C"),
            new OpCode(0x9a, "SBB D"),
            new OpCode(0x9b, "SBB E"),
            new OpCode(0x9c, "SBB H"),
            new OpCode(0x9d, "SBB L"),
            new OpCode(0x9e, "SBB M"),
            new OpCode(0x9f, "SBB A"),
            new OpCode(0xa0, "ANA B"),
            new OpCode(0xa1, "ANA C"),
            new OpCode(0xa2, "ANA D"),
            new OpCode(0xa3, "ANA E"),
            new OpCode(0xa4, "ANA H"),
            new OpCode(0xa5, "ANA L"),
            new OpCode(0xa6, "ANA M"),
            new OpCode(0xa7, "ANA A"),
            new OpCode(0xa8, "XRA B"),
            new OpCode(0xa9, "XRA C"),
            new OpCode(0xaa, "XRA D"),
            new OpCode(0xab, "XRA E"),
            new OpCode(0xac, "XRA H"),
            new OpCode(0xad, "XRA L"),
            new OpCode(0xae, "XRA M"),
            new OpCode(0xaf, "XRA A"),
            new OpCode(0xb0, "ORA B"),
            new OpCode(0xb1, "ORA C"),
            new OpCode(0xb2, "ORA D"),
            new OpCode(0xb3, "ORA E"),
            new OpCode(0xb4, "ORA H"),
            new OpCode(0xb5, "ORA L"),
            new OpCode(0xb6, "ORA M"),
            new OpCode(0xb7, "ORA A"),
            new OpCode(0xb8, "CMP B"),
            new OpCode(0xb9, "CMP C"),
            new OpCode(0xba, "CMP D"),
            new OpCode(0xbb, "CMP E"),
            new OpCode(0xbc, "CMP H"),
            new OpCode(0xbd, "CMP L"),
            new OpCode(0xbe, "CMP M"),
            new OpCode(0xbf, "CMP A"),
            new OpCode(0xc0, "RNZ"),
            new OpCode(0xc1, "POP B"),
            new OpCode(0xc2, "JNZ adr", 3),
            new OpCode(0xc3, "JMP adr", 3),
            new OpCode(0xc4, "CNZ adr", 3),
            new OpCode(0xc5, "PUSH B"),
            new OpCode(0xc6, "ADI D8", 2),
            new OpCode(0xc7, "RST 0"),
            new OpCode(0xc8, "RZ"),
            new OpCode(0xc9, "RET"),
            new OpCode(0xca, "JZ adr", 3),
            new OpCode(0xcb, "-"),
            new OpCode(0xcc, "CZ adr", 3),
            new OpCode(0xcd, "CALL adr", 3),
            new OpCode(0xce, "ACI D8", 2),
            new OpCode(0xcf, "RST 1"),
            new OpCode(0xd0, "RNC"),
            new OpCode(0xd1, "POP D"),
            new OpCode(0xd2, "JNC adr", 3),
            new OpCode(0xd3, "OUT D8", 2),
            new OpCode(0xd4, "CNC adr", 3),
            new OpCode(0xd5, "PUSH D"),
            new OpCode(0xd6, "SUI D8", 2),
            new OpCode(0xd7, "RST 2"),
            new OpCode(0xd8, "RC"),
            new OpCode(0xd9, "-"),
            new OpCode(0xda, "JC adr", 3),
            new OpCode(0xdb, "IN D8", 2),
            new OpCode(0xdc, "CC adr", 3),
            new OpCode(0xdd, "-"),
            new OpCode(0xde, "SBI D8", 2),
            new OpCode(0xdf, "RST 3"),
            new OpCode(0xe0, "RPO"),
            new OpCode(0xe1, "POP H"),
            new OpCode(0xe2, "JPO adr", 3),
            new OpCode(0xe3, "XTHL"),
            new OpCode(0xe4, "CPO adr", 3),
            new OpCode(0xe5, "PUSH H"),
            new OpCode(0xe6, "ANI D8", 2),
            new OpCode(0xe7, "RST 4"),
            new OpCode(0xe8, "RPE"),
            new OpCode(0xe9, "PCHL"),
            new OpCode(0xea, "JPE adr", 3),
            new OpCode(0xeb, "XCHG"),
            new OpCode(0xec, "CPE adr", 3),
            new OpCode(0xed, "-"),
            new OpCode(0xee, "XRI D8", 2),
            new OpCode(0xef, "RST 5"),
            new OpCode(0xf0, "RP"),
            new OpCode(0xf1, "POP PSW"),
            new OpCode(0xf2, "JP adr", 3),
            new OpCode(0xf3, "DI"),
            new OpCode(0xf4, "CP adr", 3),
            new OpCode(0xf5, "PUSH PSW"),
            new OpCode(0xf6, "ORI D8", 2),
            new OpCode(0xf7, "RST 6"),
            new OpCode(0xf8, "RM"),
            new OpCode(0xf9, "SPHL"),
            new OpCode(0xfa, "JM adr", 3),
            new OpCode(0xfb, "EI"),
            new OpCode(0xfc, "CM adr", 3),
            new OpCode(0xfd, "-"),
            new OpCode(0xfe, "CPI D8", 2),
            new OpCode(0xff, "RST 7")
        }
            .ToDictionary(op => op.Code);

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public byte Code { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Size, in bytes, of the instruction
        /// </summary>
        public int Size { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of a <see cref="OpCode"/>
        /// </summary>
        private OpCode(byte code, string description, int size = 1)
        {
            this.Code = code;
            this.Description = description;
            this.Size = size;
        }

        #endregion

        #region Methods

        /// <summary>
        /// <see cref="object.ToString"/>
        /// </summary>
        override public string ToString()
        {
            return Description;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a given <see cref="byte"/> value and translates it into an <see cref="OpCode"/>
        /// </summary>
        static public OpCode FromHex(byte value)
        {
            return codes.TryGetValue(value, out OpCode result) ? result : throw new KeyNotFoundException($"The given opcode ({value}) is unknown.");
        }

        #endregion
    }
}
