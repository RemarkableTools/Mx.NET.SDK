using System.Collections.Generic;
using Mx.NET.SDK.Core.Domain.Exceptions;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;

namespace Mx.NET.SDK.Core.Domain.Codec
{
    public class OptionalBinaryCodec : IBinaryCodec
    {
        private readonly BinaryCodec _binaryCodec;

        public OptionalBinaryCodec(BinaryCodec binaryCodec)
        {
            _binaryCodec = binaryCodec;
        }

        public string Type => TypeValue.BinaryTypes.Optional;

        public (IBinaryType Value, int BytesLength) DecodeNested(byte[] data, TypeValue type)
        {
            if (data[0] == 0x00)
            {
                return (OptionalValue.NewMissing(), 1);
            }

            if (data[0] != 0x01)
            {
                throw new BinaryCodecException("invalid buffer for optional value");
            }

            var (value, bytesLength) = _binaryCodec.DecodeNested(data.Slice(1), type.InnerType);
            return (OptionalValue.NewProvided(value), bytesLength + 1);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            if (data.Length == 0)
            {
                return OptionalValue.NewMissing();
            }

            var result = _binaryCodec.DecodeTopLevel(data, type.InnerType);
            return OptionalValue.NewProvided(result);
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var optionValue = value.ValueOf<OptionalValue>();
            if (optionValue.IsSet())
            {
                return _binaryCodec.EncodeNested(optionValue.Value);
            }

            return new byte[] { };
        }

        public byte[] EncodeTopLevel(IBinaryType value)
        {
            var optionValue = value.ValueOf<OptionalValue>();
            if (optionValue.IsSet())
                return EncodeNested(value);

            return new byte[] { };
        }
    }
}
