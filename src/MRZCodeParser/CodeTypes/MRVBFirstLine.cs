using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class MrvbFirstLine : MrzLine
    {
        internal MrvbFirstLine(string value) : base(value)
        {
        }

        protected override string Pattern => "(V[A-Z0-9<]{1})([A-Z]{3})([A-Z0-9<]{31})";

        internal override IEnumerable<FieldType> FieldTypes =>
        [
            FieldType.DocumentType,
            FieldType.CountryCode,
            FieldType.PrimaryIdentifier,
        ];
    }
}