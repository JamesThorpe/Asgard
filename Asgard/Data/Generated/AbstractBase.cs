﻿using System;

/*	This file is automatically generated by a T4 template from a data file.
	cbus-4.0-Rev-8d-Guide-6b-opcodes
	It was last generated at 12/21/2021 22:01:46.
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
                0x00 => new Ack(message),
                0x01 => new Nak(message),
                0x02 => new Hlt(message),
                0x03 => new Bon(message),
                0x04 => new Tof(message),
                0x05 => new Ton(message),
                0x06 => new Estop(message),
                0x07 => new Arst(message),
                0x08 => new Rtof(message),
                0x09 => new Rton(message),
                0x0A => new Restp(message),
                0x0C => new Rstat(message),
                0x0D => new Qnn(message),
                0x10 => new Rqnp(message),
                0x11 => new Rqmn(message),
                0x21 => new Kloc(message),
                0x22 => new Qloc(message),
                0x23 => new Dkeep(message),
                0x30 => new Dbg1(message),
                0x3F => new Extc(message),
                0x40 => new Rloc(message),
                0x41 => new Qcon(message),
                0x42 => new Snn(message),
                0x43 => new Aloc(message),
                0x44 => new Stmod(message),
                0x45 => new Pcon(message),
                0x46 => new Kcon(message),
                0x47 => new Dspd(message),
                0x48 => new Dflg(message),
                0x49 => new Dfnon(message),
                0x4A => new Dfnof(message),
                0x4C => new Sstat(message),
                0x50 => new Rqnn(message),
                0x51 => new Nnrel(message),
                0x52 => new Nnack(message),
                0x53 => new Nnlrn(message),
                0x54 => new Nnuln(message),
                0x55 => new Nnclr(message),
                0x56 => new Nnevn(message),
                0x57 => new Nerd(message),
                0x58 => new Rqevn(message),
                0x59 => new Wrack(message),
                0x5A => new Rqdat(message),
                0x5B => new Rqdds(message),
                0x5C => new Bootm(message),
                0x5D => new Enum(message),
                0x5F => new Extc1(message),
                0x60 => new Dfun(message),
                0x61 => new Gloc(message),
                0x63 => new Err(message),
                0x6F => new Cmderr(message),
                0x70 => new Evnlf(message),
                0x71 => new Nvrd(message),
                0x72 => new Nenrd(message),
                0x73 => new Rqnpn(message),
                0x74 => new Numev(message),
                0x75 => new Canid(message),
                0x7F => new Extc2(message),
                0x80 => new Rdcc3(message),
                0x82 => new Wcvo(message),
                0x83 => new Wcvb(message),
                0x84 => new Qcvs(message),
                0x85 => new Pcvs(message),
                0x90 => new Acon(message),
                0x91 => new Acof(message),
                0x92 => new Areq(message),
                0x93 => new Aron(message),
                0x94 => new Arof(message),
                0x95 => new Evuln(message),
                0x96 => new Nvset(message),
                0x97 => new Nvans(message),
                0x98 => new Ason(message),
                0x99 => new Asof(message),
                0x9A => new Asrq(message),
                0x9B => new Paran(message),
                0x9C => new Reval(message),
                0x9D => new Arson(message),
                0x9E => new Arsof(message),
                0x9F => new Extc3(message),
                0xA0 => new Rdcc4(message),
                0xA2 => new Wcvs(message),
                0xB0 => new Acon1(message),
                0xB1 => new Acof1(message),
                0xB2 => new Reqev(message),
                0xB3 => new Aron1(message),
                0xB4 => new Arof1(message),
                0xB5 => new Neval(message),
                0xB6 => new Pnn(message),
                0xB8 => new Ason1(message),
                0xB9 => new Asof1(message),
                0xBD => new Arson1(message),
                0xBE => new Arsof1(message),
                0xBF => new Extc4(message),
                0xC0 => new Rdcc5(message),
                0xC1 => new Wcvoa(message),
                0xCF => new Fclk(message),
                0xD0 => new Acon2(message),
                0xD1 => new Acof2(message),
                0xD2 => new Evlrn(message),
                0xD3 => new Evans(message),
                0xD4 => new Aron2(message),
                0xD5 => new Arof2(message),
                0xD8 => new Ason2(message),
                0xD9 => new Asof2(message),
                0xDD => new Arson2(message),
                0xDE => new Arsof2(message),
                0xDF => new Extc5(message),
                0xE0 => new Rdcc6(message),
                0xE1 => new Ploc(message),
                0xE2 => new Name(message),
                0xE3 => new Stat(message),
                0xEF => new Params(message),
                0xF0 => new Acon3(message),
                0xF1 => new Acof3(message),
                0xF2 => new Enrsp(message),
                0xF3 => new Aron3(message),
                0xF4 => new Arof3(message),
                0xF5 => new Evlrni(message),
                0xF6 => new Acdat(message),
                0xF7 => new Ardat(message),
                0xF8 => new Ason3(message),
                0xF9 => new Asof3(message),
                0xFA => new Ddes(message),
                0xFB => new Ddrs(message),
                0xFD => new Arson3(message),
                0xFE => new Arsof3(message),
                0xFF => new Extc6(message),
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
