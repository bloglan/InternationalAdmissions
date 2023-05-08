namespace MRZCodeParser
{
    public class Field
    {
        public FieldType Type { get; }
        public string Value { get; }

        public Field(FieldType type, string value)
        {
            this.Type = type;
            this.Value = value;
        }
    }
}