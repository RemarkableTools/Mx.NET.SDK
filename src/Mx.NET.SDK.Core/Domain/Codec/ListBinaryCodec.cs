using System.Collections.Generic;
using System.Linq;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;

namespace Mx.NET.SDK.Core.Domain.Codec
{
    public class ListBinaryCodec : IBinaryCodec
    {
        private readonly BinaryCodec _binaryCodec;
        private readonly List<IBinaryCodec> _codecs;

        public ListBinaryCodec(BinaryCodec binaryCodec)
        {
            _binaryCodec = binaryCodec;

            _codecs = new List<IBinaryCodec>
            {
                new NumericBinaryCodec(),
                new AddressBinaryCodec(),
                new BooleanBinaryCodec(),
                new BytesBinaryCodec(),
                new TokenIdentifierCodec(),
            };
        }

        public string Type => TypeValue.BinaryTypes.List;

        public (IBinaryType Value, int BytesLength) DecodeNested(byte[] data, TypeValue type)
        {
            var result = new List<IBinaryType>();
            var buffer = data.ToList();
            var offset = 0;
            var listLen = _binaryCodec.DecodeNested(buffer.Take(4).ToArray(), TypeValue.U32TypeValue);
            buffer = buffer.Skip(4).ToList();
            int i = 0;
            while (buffer.Any() && i < ((NumericValue)listLen.Value).Number)
            {
                i++;
                var (value, bytesLength) = _binaryCodec.DecodeNested(buffer.ToArray(), type.InnerType);
                result.Add(value);
                offset += bytesLength;
                buffer = buffer.Skip(bytesLength).ToList();
            }

            var multiValue = new ListValue(type, result);
            return (multiValue, offset + 4);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            var decoded = DecodeNested(data, type);
            return decoded.Value;
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var buffers = new List<byte[]>();

            foreach (var multiValue in ((ArrayValue)value).Values)
            {
                var codec = _codecs.SingleOrDefault(c => c.Type == multiValue.Type.BinaryType);
                var fieldBuffer = codec.EncodeNested(multiValue);
                buffers.Add(fieldBuffer);
            }

            var data = buffers.SelectMany(s => s);
            return data.ToArray();
        }

        public byte[] EncodeTopLevel(IBinaryType value)
        {
            return EncodeNested(value);
        }
    }
}
