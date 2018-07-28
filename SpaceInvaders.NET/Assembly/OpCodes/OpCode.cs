﻿namespace SpaceInvaders.Assembly
{
	/// <summary>
	/// Represents an 8080's OpCode
	/// </summary>
	public enum OpCode : ushort
	{
		NOP = 0x00,
		LXIBD16 = 0x01, 
		STAXB = 0x02,
		INXB = 0x03,
		INRB = 0x04,
		DCRB = 0x05,
		MVIBD8 = 0x06,
		RLC = 0x07,
		NotImplemented1 = 0x08, 
		DADB = 0x09,
		LDAXB = 0x0A,
		DCXB = 0x0B,
		INRC = 0x0C,
		DCRC = 0x0D,
		MVICD8 = 0x0E,
		RRC = 0x0F,
		NotImplemented2 = 0x10,
		LXIDD16 = 0x11,
		STAXD = 0x12,
		INXD = 0x13,
		INRD = 0x14,
		DCRD = 0x15,
		MVIDD8 = 0x16,
		RAL = 0x17,
		NotImplemented3 = 0x18,
		DADD = 0x19,
		LDAXD = 0x1A,
		DCXD = 0x1B,
		INRE = 0x1C,
		DCRE = 0x1D,
		MVIED8 = 0x1E,
		RAR = 0x1F,
		RIM = 0x20,
		LXIHD16 = 0x21,
		SHLD = 0x22,
		INXH = 0x23,
		INRH = 0x24,
		DCRH = 0x25,
		MVIHD8 = 0x26,
		DAA = 0x27,
		NotImplemented4 = 0x28, 
		DADH = 0x29,
		LHLD = 0x2A,
		DCXH = 0x2B,
		INRL = 0x2C,
		DCRL = 0x2D,
		MVILD8 = 0x2E,
		CMA = 0x2F,
		SIM = 0x30,
		LXISPD16 = 0x31,
		STA = 0x32,
		INXSP = 0x33,
		INRM = 0x34,
		DCRM = 0x35,
		MVIMD8 = 0x36,
		STC = 0x37,
		NotImplemented5 = 0x38,
		DADSP = 0x39,
		LDA = 0x3A,
		DCXSP = 0x3B,
		INRA = 0x3C, 
		DCRA = 0x3D,
		MVIAD8 = 0x3E,
		CMC = 0x3F, 
		MOVBB = 0x40,
		MOVBC = 0x41,
		MOVBD = 0x42,
		MOVBE = 0x43,
		MOVBH = 0x44,
		MOVBL = 0x45,
		MOVBM = 0x46,
		MOVBA = 0x47,
		MOVCB = 0x48,
		MOVCC = 0x49,
		MOVCD = 0x4A,
		MOVCE = 0x4B,
		MOVCH = 0x4C,
		MOVCL = 0x4D,
		MOVCM = 0x4E,
		MOVCA = 0x4F,
		MOVDB = 0x50,
		MOVDC = 0x51,
		MOVDD = 0x52,
		MOVDE = 0x53,
		MOVDH = 0x54,
		MOVDL = 0x55,
		MOVDM = 0x56,
		MOVDA = 0x57,
		MOVEB = 0x58,
		MOVEC = 0x59,
		MOVED = 0x5A,
		MOVEE = 0x5B,
		MOVEH = 0x5C,
		MOVEL = 0x5D,
		MOVEM = 0x5E,
		MOVEA = 0x5F,
		MOVHB = 0x60,
		MOVHC = 0x61,
		MOVHD = 0x62,
		MOVHE = 0x63,
		MOVHH = 0x64,
		MOVHL = 0x65,
		MOVHM = 0x66,
		MOVHA = 0x67,
		MOVLB = 0x68,
		MOVLC = 0x69,
		MOVLD = 0x6A,
		MOVLE = 0x6B,
		MOVLH = 0x6C,
		MOVLL = 0x6D,
		MOVLM = 0x6E,
		MOVLA = 0x6F,
		MOVMB = 0x70,
		MOVMC = 0x71,
		MOVMD = 0x72,
		MOVME = 0x73,
		MOVMH = 0x74,
		MOVML = 0x75,
		HLT = 0x76,
		MOVMA = 0x77,
		MOVAB = 0x78,
		MOVAC = 0x79,
		MOVAD = 0x7A,
		MOVAE = 0x7B,
		MOVAH = 0x7C,
		MOVAL = 0x7D,
		MOVAM = 0x7E,
		MOVAA = 0x7F,
		ADDB = 0x80,
		ADDC = 0x81,
		ADDD = 0x82,
		ADDE = 0x83,
		ADDH = 0x84,
		ADDL = 0x85,
		ADDM = 0x86,
		ADDA = 0x87,
		ADCB = 0x88,
		ADCC = 0x89,
		ADCD = 0x8A,
		ADCE = 0x8B,
		ADCH = 0x8C,
		ADCL = 0x8D,
		ADCM = 0x8E,
		ADCA = 0x8F,
		SUBB = 0x90,
		SUBC = 0x91,
		SUBD = 0x92,
		SUBE = 0x93,
		SUBH = 0x94,
		SUBL = 0x95,
		SUBM = 0x96,
		SUBA = 0x97,
		SBBB = 0x98,
		SBBC = 0x99,
		SBBD = 0x9A,
		SBBE = 0x9B,
		SBBH = 0x9C,
		SBBL = 0x9D,
		SBBM = 0x9E,
		SBBA = 0x9F,
		ANAB = 0xA0,
		ANAC = 0xA1,
		ANAD = 0xA2,
		ANAE = 0xA3,
		ANAH = 0xA4,
		ANAL = 0xA5,
		ANAM = 0xA6,
		ANAA = 0xA7,
		XRAB = 0xA8,
		XRAC = 0xA9,
		XRAD = 0xAA,
		XRAE = 0xAB,
		XRAH = 0xAC,
		XRAL = 0xAD,
		XRAM = 0xAE,
		XRAA = 0xAF,
		ORAB = 0xB0,
		ORAC = 0xB1,
		ORAD = 0xB2,
		ORAE = 0xB3,
		ORAH = 0xB4,
		ORAL = 0xB5,
		ORAM = 0xB6,
		ORAA = 0xB7,
		CMPB = 0xB8,
		CMPC = 0xB9,
		CMPD = 0xBA,
		CMPE = 0xBB,
		CMPH = 0xBC,
		CMPL = 0xBD,
		CMPM = 0xBE,
		CMPA = 0xBF,
		RNZ = 0xC0, 
		POPB = 0xC1,
		JNZ = 0xC2,
		JMP = 0xC3,
		CNZ = 0xC4,
		PUSHB = 0xC5,
		ADID8 = 0xC6,
		RST0 = 0xC7,
		RZ = 0xC8, 
		RET = 0xC9, 
		JZ = 0xCA, 
		NotImplemented6 = 0xCB,
		CZ = 0xCC, 
		CALL = 0xCD, 
		ACID8 = 0xCE, 
		RST1 = 0xCF, 
		RNC = 0xD0, 
		POPD = 0xD1,
		JNC = 0xD2, 
		OUTD8 = 0xD3, 
		CNC = 0xD4, 
		PUSHD = 0xD5,
		SUID8 = 0xD6, 
		RST2 = 0xD7,
		RC = 0xD8, 
		NotImplemented7 = 0xD9,
		JC = 0xDA, 
		IND8 = 0xDB,
		CC = 0xDC,
		NotImplemented8 = 0xDD, 
		SBID8 =0xDE, 
		RST3 = 0xDF,
		RPO = 0xE0,
		POPH = 0xE1,
		JPO = 0xE2,
		XTHL = 0xE3,
		CPO = 0xE4,
		PUSHH = 0xE5,
		ANID8 = 0xE6,
		RST4 = 0xE7,
		RPE = 0xE8,
		PCHL = 0xE9,
		JPE = 0xEA,
		XCHG = 0xEB,
		CPE = 0xEC,
		NotImplemented9 = 0xED,
		XRID8 = 0xEE, 
		RST5 = 0xEF,
		RP = 0xF0,
		POPPSW = 0xF1,
		JP = 0xF2,
		DI = 0xF3,
		CP = 0xF4,
		PUSHPSW = 0xF5,
		ORID8 =0xF6,
		RST6 = 0xF7,
		RM = 0xF8,
		SPHL = 0xF9,
		JM = 0xFA,
		EI = 0xFB,
		CM = 0xFC,
		NotImplemented10 = 0xFD,
		CPID8 = 0xFE,
		RST7 = 0xFF
	}
}
