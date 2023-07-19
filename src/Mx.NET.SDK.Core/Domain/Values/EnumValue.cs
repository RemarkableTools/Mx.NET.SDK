using Mx.NET.SDK.Core.Domain.Helper;
using System.Collections.Generic;

namespace Mx.NET.SDK.Core.Domain.Values
{
    public class EnumValue : BaseBinaryValue
    {
        //public EnumField Discriminant { get; }
        public EnumField Value { get; }

        public EnumValue(TypeValue structType, EnumField discriminant) : base(structType)
        {
            //Discriminant = discriminant;
            Value = discriminant;
        }

        public override string ToString()
        {
            return Value.Name;
        }

        public override T ToObject<T>()
        {
            return JsonWrapper.Deserialize<T>(ToJson());
        }

        public override string ToJson()
        {
            var dic = new Dictionary<string, object>
            {
                { Value.Name, Value.Discriminant.ToString() }
            };

            return JsonWrapper.Serialize(dic);
        }
    }
}
