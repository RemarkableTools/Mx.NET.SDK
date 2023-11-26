using Mx.NET.SDK.Core.Domain.Values;

namespace Mx.NET.SDK.Core.Domain.Codec
{
    public class StringBinaryCodec : IBinaryCodec
    {
        private readonly BytesBinaryCodec _bytesBinaryCodec;

        public StringBinaryCodec()
        {
            _bytesBinaryCodec = new BytesBinaryCodec();
        }
        public string Type => TypeValue.BinaryTypes.String;

        public (IBinaryType Value, int BytesLength) DecodeNested(byte[] data, TypeValue type)
        {
            var (value, bytesLength) = _bytesBinaryCodec.DecodeNested(data, type);
            return (StringValue.FromUtf8(value.ValueOf<StringValue>().ToString()), bytesLength);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            return new StringValue(data, type);
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var stringValueObject = value.ValueOf<StringValue>();
            var buffer = BytesValue.FromUtf8(stringValueObject.ToString());

            return _bytesBinaryCodec.EncodeNested(buffer);
        }

        public byte[] EncodeTopLevel(IBinaryType value)
        {
            var bytes = value.ValueOf<StringValue>();
            return bytes.Buffer;
        }
    }
}
