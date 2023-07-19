using Mx.NET.SDK.Core.Domain.Values;
using System.Collections.Generic;
using System.Linq;

namespace Mx.NET.SDK.Core.Domain.Codec
{
    public class EnumBinaryCodec : IBinaryCodec
    {
        private readonly BinaryCodec _binaryCodec;
        public string Type => TypeValue.BinaryTypes.Enum;

        public EnumBinaryCodec(BinaryCodec binaryCodec)
        {
            _binaryCodec = binaryCodec;
        }

        public (IBinaryType Value, int BytesLength) DecodeNested(byte[] data, TypeValue type)
        {
            var fieldDefinitions = type.GetFieldDefinitions();

            var buffer = data.ToList();
            var offset = 0;

            var (value, bytesLength) = _binaryCodec.DecodeNested(buffer.ToArray(), fieldDefinitions[0].Type);

            offset += bytesLength;
            _ = buffer.Skip(bytesLength).ToList();

            var intVal = int.Parse(value.ToString());

            var structObject = new EnumValue(type, new EnumField(fieldDefinitions[intVal].Name, value));

            return (structObject, offset);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            var decoded = DecodeNested(data, type);
            return decoded.Value;
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var structValue = value.ValueOf<StructValue>();
            var buffers = new List<byte[]>();
            var fields = structValue.Fields;

            foreach (var field in fields)
            {
                var fieldBuffer = _binaryCodec.EncodeNested(field.Value);
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
