using Mx.NET.SDK.Core.Domain.Helper;
using System.Linq;

namespace Mx.NET.SDK.Core.Domain.Values
{
    public class EnumValue : BaseBinaryValue
    {
        public string Name { get; }
        public int Discriminant { get; }
        public Field[] Fields { get; }

        public EnumValue(TypeValue enumType, VariantDefinition variant, Field[] fields) : base(enumType)
        {
            Name = variant.Name;
            Discriminant = variant.Discriminant;
            Fields = fields;
        }

        public override string ToString()
        {
            return Discriminant.ToString();
        }

        public override T ToObject<T>()
        {
            return JsonWrapper.Deserialize<T>(ToJson());
        }

        public override string ToJson()
        {
            return JsonUnqtWrapper.Serialize((Name, Fields?.Select(f => f.Value.ToJson())));
        }
    }
}
