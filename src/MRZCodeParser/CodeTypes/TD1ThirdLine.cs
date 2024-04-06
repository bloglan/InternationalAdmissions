using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class Td1ThirdLine(string value) : MrzLine(value)
    {
        protected override string Pattern => "([A-Z0-9<]{30})";

        internal override IEnumerable<FieldType> FieldTypes => [FieldType.Names];
    }
}