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
            var fields = new List<EnumField>();
            var originalBuffer = data;
            var offset = 0;

            foreach (var fieldDefinition in fieldDefinitions)
            {
                var (value, bytesLength) = _binaryCodec.DecodeNested(data, fieldDefinition.Type);
                fields.Add(new EnumField(fieldDefinition.Name, value));
                offset += bytesLength;
                data = originalBuffer.Slice(offset);
            }

            var enumValue = new EnumValue(type, fields.ToArray());
            return (enumValue, offset);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            var (value, _) = DecodeNested(data, type);
            return value;
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var enumValue = value.ValueOf<EnumValue>();
            var buffers = new List<byte[]>();
            var fields = enumValue.Fields;

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
