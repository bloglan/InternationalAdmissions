using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MRZCodeParser
{
    public abstract class MrzLine
    {
        public string Value { get; }

        public int Length => this.Value?.Length ?? 0;

        public FieldsCollection Fields
        {
            get
            {
                var regex = new Regex(this.Pattern);
                var match = regex.Match(this.Value);

                if (!match.Success)
                {
                    throw new MrzCodeException($"Line: {this.Value} does not match to pattern: {this.Pattern}");
                }

                var fields = new List<Field>();
                for (var i = 0; i < this.FieldTypes.Count(); i++)
                {
                    fields.Add(new Field(
                        this.FieldTypes.ElementAt(i),
                        new ValueCleaner(match.Groups[i + 1].Value).Clean()));
                }

                return new FieldsCollection(fields);
            }
        }

        protected abstract string Pattern { get; }

        internal abstract IEnumerable<FieldType> FieldTypes { get; }

        internal MrzLine(string value)
        {
            this.Value = value;
        }
    }
}