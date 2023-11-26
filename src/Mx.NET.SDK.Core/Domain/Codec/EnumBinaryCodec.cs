using Mx.NET.SDK.Core.Domain.Helper;
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
            var originalBuffer = data;
            var offset = 0;

            var (discriminant, lengthOfDiscriminant) = ReadDiscriminant(data);
            offset += lengthOfDiscriminant;
            data = originalBuffer.Slice(offset);

            var index = int.Parse(discriminant.ToString());
            var variantDefinitions = type.GetVariantDefinitions();
            var fieldDefinitions = variantDefinitions[index].Fields ?? new FieldDefinition[0];
            var fields = new List<Field>();

            foreach (var fieldDefinition in fieldDefinitions)
            {
                var (value, fieldsLength) = _binaryCodec.DecodeNested(data, fieldDefinition.Type);
                fields.Add(new Field(fieldDefinition.Name, value));
                offset += fieldsLength;
                data = originalBuffer.Slice(offset);
            }

            var enumValue = new EnumValue(type, variantDefinitions[index], fields.ToArray());
            return (enumValue, offset);
        }

        private (IBinaryType Value, int BytesLength) ReadDiscriminant(byte[] data)
        {
            return _binaryCodec.DecodeNested(data, TypeValue.U8TypeValue);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            var (value, _) = DecodeNested(data, type);
            return value;
        }

        public byte[] EncodeNested(IBinaryType value)
        {
            var enumValue = value.ValueOf<EnumValue>();
            var buffer = new List<byte[]>();

            var discriminant = new NumericValue(TypeValue.U8TypeValue, enumValue.Discriminant);
            var discriminantBuffer = _binaryCodec.EncodeNested(discriminant);

            buffer.Add(discriminantBuffer);
            foreach (var field in enumValue.Fields)
            {
                var fieldBuffer = _binaryCodec.EncodeNested(field.Value);
                buffer.Add(fieldBuffer);
            }

            var data = buffer.SelectMany(s => s);
            return data.ToArray();
        }

        public byte[] EncodeTopLevel(IBinaryType value)
        {
            var enumValue = value.ValueOf<EnumValue>();
            var hasFields = enumValue.Fields?.Length > 0;
            var buffer = new List<byte[]>();

            var discriminant = new NumericValue(TypeValue.U8TypeValue, enumValue.Discriminant);
            var discriminantBuffer = hasFields ? _binaryCodec.EncodeNested(discriminant) : _binaryCodec.EncodeTopLevel(discriminant);
            buffer.Add(discriminantBuffer);

            foreach (var field in enumValue.Fields)
            {
                var fieldBuffer = _binaryCodec.EncodeNested(field.Value);
                buffer.Add(fieldBuffer);
            }

            var data = buffer.SelectMany(s => s);
            return data.ToArray();
        }
    }
}
