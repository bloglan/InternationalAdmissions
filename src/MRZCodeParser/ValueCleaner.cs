namespace MRZCodeParser
{
    internal class ValueCleaner
    {
        private readonly string _value;

        internal ValueCleaner(string value)
        {
            this._value = value;
        }

        internal string Clean()
        {
            return _value.TrimEnd('<')
                .Replace("<<", ", ")
                .Replace("<", " ");
        }
    }
}