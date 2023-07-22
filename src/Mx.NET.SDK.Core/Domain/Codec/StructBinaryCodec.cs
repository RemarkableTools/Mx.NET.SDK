﻿using System.Collections.Generic;
using System.Linq;
using Mx.NET.SDK.Core.Domain.Helper;
using Mx.NET.SDK.Core.Domain.Values;

namespace Mx.NET.SDK.Core.Domain.Codec
{
    public class StructBinaryCodec : IBinaryCodec
    {
        private readonly BinaryCodec _binaryCodec;
        public string Type => TypeValue.BinaryTypes.Struct;

        public StructBinaryCodec(BinaryCodec binaryCodec)
        {
            _binaryCodec = binaryCodec;
        }

        public (IBinaryType Value, int BytesLength) DecodeNested(byte[] data, TypeValue type)
        {
            var fieldDefinitions = type.GetFieldDefinitions();
            var fields = new List<StructField>();
            var originalBuffer = data;
            var offset = 0;

            foreach (var fieldDefinition in fieldDefinitions)
            {
                var (value, bytesLength) = _binaryCodec.DecodeNested(data, fieldDefinition.Type);
                fields.Add(new StructField(fieldDefinition.Name, value));
                offset += bytesLength;
                data = originalBuffer.Slice(offset);
            }

            var structValue = new StructValue(type, fields.ToArray());
            return (structValue, offset);
        }

        public IBinaryType DecodeTopLevel(byte[] data, TypeValue type)
        {
            var (value, _) = DecodeNested(data, type);
            return value;
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
