namespace Mx.NET.SDK.Core.Domain.Values
{
    public class VariantDefinition
    {
        public string Name { get; }
        public string Description { get; }
        public int Discriminant { get; }
        public FieldDefinition[] Fields { get; }

        public VariantDefinition(string name, string description, int discriminant, FieldDefinition[] fields)
        {
            Name = name;
            Description = description;
            Discriminant = discriminant;
            Fields = fields;
        }
    }
}
