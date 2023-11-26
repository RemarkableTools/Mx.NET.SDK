namespace Mx.NET.SDK.Core.Domain.Values
{
    public class Field
    {
        public string Name { get; }
        public IBinaryType Value { get; }

        public Field(string name, IBinaryType value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
