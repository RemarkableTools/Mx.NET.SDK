using System.Text;
using Mx.NET.SDK.Core.Domain.Helper;

namespace Mx.NET.SDK.Core.Domain.Values
{
    public class StringValue : BaseBinaryValue
    {
        public string Value { get; }
        public byte[] Buffer { get; }

        public StringValue(byte[] data, TypeValue type) : base(type)
        {
            Buffer = data;
            Value = Encoding.UTF8.GetString(data);
        }

        public static StringValue FromUtf8(string utf8String)
        {
            return new StringValue(Encoding.UTF8.GetBytes(utf8String), TypeValue.StringValue);
        }

        public static StringValue FromHex(string hexString)
        {
            return new StringValue(Converter.FromHexString(hexString), TypeValue.StringValue);
        }

        public static StringValue FromBuffer(byte[] data)
        {
            return new StringValue(data, TypeValue.StringValue);
        }

        public int GetLength()
        {
            return Value.Length;
        }

        public override string ToString()
        {
            return Value;
        }

        public override string ToJson()
        {
            return ToString();
        }
    }
}
