﻿using System;

/*	This file is automatically generated by a T4 template from a data file.
	C:\Users\james\Dropbox\Development\Asgard\Asgard\Data\Generated\cbus-opcodes.txt
	Any changes made manually will be lost when the file is regenerated.
*/

namespace Asgard.Data
{
	#region Licence

/*
 *	This work is licensed under the:
 *	    Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License.
 *	To view a copy of this license, visit:
 *	    http://creativecommons.org/licenses/by-nc-sa/4.0/
 *	or send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.
 *	
 *	License summary:
 *	  You are free to:
 *	    Share, copy and redistribute the material in any medium or format
 *	    Adapt, remix, transform, and build upon the material
 *	
 *	  The licensor cannot revoke these freedoms as long as you follow the license terms.
 *	
 *	  Attribution : You must give appropriate credit, provide a link to the license,
 *	                 and indicate if changes were made. You may do so in any reasonable manner,
 *	                 but not in any way that suggests the licensor endorses you or your use.
 *	
 *	  NonCommercial : You may not use the material for commercial purposes. **(see note below)
 *	
 *	  ShareAlike : If you remix, transform, or build upon the material, you must distribute
 *	                your contributions under the same license as the original.
 *	
 *	  No additional restrictions : You may not apply legal terms or technological measures that
 *	                                legally restrict others from doing anything the license permits.
 *	
 *	 ** For commercial use, please contact the original copyright holder(s) to agree licensing terms
 *	
 *	  This software is distributed in the hope that it will be useful, but WITHOUT ANY
 *	  WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE

 *	*/
	#endregion

	#region History

/*	Date		Author
 *	2021-11-06	Richard Crawshaw	Original from Developers' Guide for CBUS version 6b

 *	*/

	#endregion

	#region Common abstract base class

	/// <summary>
	/// Abstract base class for all OpCodes.
	/// </summary>
	public abstract partial class OpCodeData :
		ICbusOpCode
	{
		public static OpCodeData Create(ICbusMessage message)
		{
			return message[0] switch
			{
                0x00 => new ACK(message),
                0x01 => new NAK(message),
                0x02 => new HLT(message),
                0x03 => new BON(message),
                0x04 => new TOF(message),
                0x05 => new TON(message),
                0x06 => new ESTOP(message),
                0x07 => new ARST(message),
                0x08 => new RTOF(message),
                0x09 => new RTON(message),
                0x0A => new RESTP(message),
                0x0C => new RSTAT(message),
                0x0D => new QNN(message),
                0x10 => new RQNP(message),
                0x11 => new RQMN(message),
                0x21 => new KLOC(message),
                0x22 => new QLOC(message),
                0x23 => new DKEEP(message),
                0x30 => new DBG1(message),
                0x3F => new EXTC(message),
                0x40 => new RLOC(message),
                0x41 => new QCON(message),
                0x42 => new SNN(message),
                0x43 => new ALOC(message),
                0x44 => new STMOD(message),
                0x45 => new PCON(message),
                0x46 => new KCON(message),
                0x47 => new DSPD(message),
                0x48 => new DFLG(message),
                0x49 => new DFNON(message),
                0x4A => new DFNOF(message),
                0x4C => new SSTAT(message),
                0x50 => new RQNN(message),
                0x51 => new NNREL(message),
                0x52 => new NNACK(message),
                0x53 => new NNLRN(message),
                0x54 => new NNULN(message),
                0x55 => new NNCLR(message),
                0x56 => new NNEVN(message),
                0x57 => new NERD(message),
                0x58 => new RQEVN(message),
                0x59 => new WRACK(message),
                0x5A => new RQDAT(message),
                0x5B => new RQDDS(message),
                0x5C => new BOOTM(message),
                0x5D => new ENUM(message),
                0x5F => new EXTC1(message),
                0x60 => new DFUN(message),
                0x61 => new GLOC(message),
                0x63 => new ERR(message),
                0x6F => new CMDERR(message),
                0x70 => new EVNLF(message),
                0x71 => new NVRD(message),
                0x72 => new NENRD(message),
                0x73 => new RQNPN(message),
                0x74 => new NUMEV(message),
                0x75 => new CANID(message),
                0x7F => new EXTC2(message),
                0x80 => new RDCC3(message),
                0x82 => new WCVO(message),
                0x83 => new WCVB(message),
                0x84 => new QCVS(message),
                0x85 => new PCVS(message),
                0x90 => new ACON(message),
                0x91 => new ACOF(message),
                0x92 => new AREQ(message),
                0x93 => new ARON(message),
                0x94 => new AROF(message),
                0x95 => new EVULN(message),
                0x96 => new NVSET(message),
                0x97 => new NVANS(message),
                0x98 => new ASON(message),
                0x99 => new ASOF(message),
                0x9A => new ASRQ(message),
                0x9B => new PARAN(message),
                0x9C => new REVAL(message),
                0x9D => new ARSON(message),
                0x9E => new ARSOF(message),
                0x9F => new EXTC3(message),
                0xA0 => new RDCC4(message),
                0xA2 => new WCVS(message),
                0xB0 => new ACON1(message),
                0xB1 => new ACOF1(message),
                0xB2 => new REQEV(message),
                0xB3 => new ARON1(message),
                0xB4 => new AROF1(message),
                0xB5 => new NEVAL(message),
                0xB6 => new PNN(message),
                0xB8 => new ASON1(message),
                0xB9 => new ASOF1(message),
                0xBD => new ARSON1(message),
                0xBE => new ARSOF1(message),
                0xBF => new EXTC4(message),
                0xC0 => new RDCC5(message),
                0xC1 => new WCVOA(message),
                0xCF => new FCLK(message),
                0xD0 => new ACON2(message),
                0xD1 => new ACOF2(message),
                0xD2 => new EVLRN(message),
                0xD3 => new EVANS(message),
                0xD4 => new ARON2(message),
                0xD5 => new AROF2(message),
                0xD8 => new ASON2(message),
                0xD9 => new ASOF2(message),
                0xDD => new ARSON2(message),
                0xDE => new ARSOF2(message),
                0xDF => new EXTC5(message),
                0xE0 => new RDCC6(message),
                0xE1 => new PLOC(message),
                0xE2 => new NAME(message),
                0xE3 => new STAT(message),
                0xEF => new PARAMS(message),
                0xF0 => new ACON3(message),
                0xF1 => new ACOF3(message),
                0xF2 => new ENRSP(message),
                0xF3 => new ARON3(message),
                0xF4 => new AROF3(message),
                0xF5 => new EVLRNI(message),
                0xF6 => new ACDAT(message),
                0xF7 => new ARDAT(message),
                0xF8 => new ASON3(message),
                0xF9 => new ASOF3(message),
                0xFA => new DDES(message),
                0xFB => new DDRS(message),
                0xFD => new ARSON3(message),
                0xFE => new ARSOF3(message),
                0xFF => new EXTC6(message),
				_ => null,
			};
		}
	}

	#endregion

	#region Abstract base class for OpCodes with 0 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 0 data bytes.
	/// </summary>
	public abstract partial class OpCodeData0 : OpCodeData
	{
		public const int DATA_LENGTH = 0;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData0(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 1 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 1 data bytes.
	/// </summary>
	public abstract partial class OpCodeData1 : OpCodeData
	{
		public const int DATA_LENGTH = 1;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData1(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 2 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 2 data bytes.
	/// </summary>
	public abstract partial class OpCodeData2 : OpCodeData
	{
		public const int DATA_LENGTH = 2;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData2(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 3 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 3 data bytes.
	/// </summary>
	public abstract partial class OpCodeData3 : OpCodeData
	{
		public const int DATA_LENGTH = 3;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData3(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 4 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 4 data bytes.
	/// </summary>
	public abstract partial class OpCodeData4 : OpCodeData
	{
		public const int DATA_LENGTH = 4;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData4(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 5 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 5 data bytes.
	/// </summary>
	public abstract partial class OpCodeData5 : OpCodeData
	{
		public const int DATA_LENGTH = 5;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData5(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 6 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 6 data bytes.
	/// </summary>
	public abstract partial class OpCodeData6 : OpCodeData
	{
		public const int DATA_LENGTH = 6;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData6(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

	#region Abstract base class for OpCodes with 7 data bytes

	/// <summary>
	/// Abstract base class for OpCodes with 7 data bytes.
	/// </summary>
	public abstract partial class OpCodeData7 : OpCodeData
	{
		public const int DATA_LENGTH = 7;

		public override sealed int DataLength => DATA_LENGTH;

		protected OpCodeData7(ICbusMessage cbusMessage) : base(cbusMessage) { }
	}
	
	#endregion

}
