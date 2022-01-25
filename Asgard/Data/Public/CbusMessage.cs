﻿using System;
using System.Linq;

namespace Asgard.Data
{
    public class CbusMessage :
        ICbusMessage
    {
        #region Properties and indexers

        public byte[] Data { get; }

        public int Length => this.Data.Length;

        public byte this[int index]
        {
            get => this.Data[index];
            set => this.Data[index] = value;
        }

        private readonly Lazy<ICbusOpCode> lazyOpCode;

        #endregion

        #region Constructors

        protected CbusMessage(byte[] data)
        {
            var length = (data[0] >> 5) + 1;
            this.Data = new byte[length];
            data.CopyTo(this.Data, 0);

            lazyOpCode = new Lazy<ICbusOpCode>(() => OpCodeData.Create(this));
        }

        #endregion

        #region Methods

        public static ICbusMessage Create(byte[] data) => new CbusMessage(data);

        
        public ICbusOpCode GetOpCode() => lazyOpCode.Value;

        #endregion

        #region Overrides

        public override string ToString() =>
            $"L:{this.Length} {string.Join(" ", this.Data.Select(d => $"0x{d:X2}"))}";

        #endregion
    }
}
