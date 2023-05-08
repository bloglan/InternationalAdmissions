using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser
{
    public class FieldsCollection
    {
        public IEnumerable<Field> Fields { get; }

        internal FieldsCollection(IEnumerable<Field> fields)
        {
            this.Fields = fields;
        }

        public Field this[FieldType type] => this.Fields.Single(x => x.Type == type);
    }
}