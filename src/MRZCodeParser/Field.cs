namespace MRZCodeParser
{
    public class Field(FieldType type, string value)
    {
        public FieldType Type { get; } = type;
        public string Value { get; } = value;
    }
}