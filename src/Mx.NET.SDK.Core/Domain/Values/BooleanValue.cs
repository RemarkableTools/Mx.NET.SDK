﻿namespace Mx.NET.SDK.Core.Domain.Values
{
    public class BooleanValue : BaseBinaryValue
    {
        private readonly bool _value;

        public BooleanValue(bool value)
            : base(TypeValue.BooleanValue)
        {
            _value = value;
        }

        public static BooleanValue From(bool value)
        {
            return new BooleanValue(value);
        }

        public bool IsTrue()
        {
            return _value;
        }

        public bool IsFalse()
        {
            return _value == false;
        }

        public override string ToString()
        {
            return _value.ToString().ToLower();
        }

        public override string ToJson()
        {
            return ToString();
        }
    }
}
