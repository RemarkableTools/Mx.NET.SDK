using Mx.NET.SDK.Core.Domain.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.NET.SDK.Core.Domain.Values
{
    public class ListValue : BaseBinaryValue
    {
        public List<IBinaryType> Values { get; }

        public ListValue(TypeValue type, List<IBinaryType> values) : base(type)
        {
            Values = values;
        }

        public static ListValue From(params IBinaryType[] values)
        {
            var t = values.Select(s => s.Type).ToArray();
            return new ListValue(TypeValue.ListValue(TypeValue.FromRustType(values.GetType().GetElementType().Name.Replace("Value", ""))), values.ToList());
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Type.Name);
            foreach (var value in Values)
            {
                builder.AppendLine($"{value}");
            }

            return builder.ToString();
        }

        public override T ToObject<T>()
        {
            return JsonWrapper.Deserialize<T>(ToJson());
        }

        public override string ToJson()
        {
            var list = new List<object>();
            for (var i = 0; i < Values.Count; i++)
            {
                var value = Values.ToArray()[i];
                if (value.Type.BinaryType == TypeValue.BinaryTypes.Struct)
                {
                    var json = value.ToJson();
                    var jsonObject = JsonWrapper.Deserialize<object>(json);
                    list.Add(jsonObject);
                }
                else
                {
                    list.Add(value.ToString());
                }
            }

            return JsonWrapper.Serialize(list);
        }
    }
}
