using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class Td3FirstLine : MrzLine
    {
        internal Td3FirstLine(string value) : base(value)
        {
        }

        protected override string Pattern => "(P[A-Z0-9<]{1})([A-Z<]{3})([A-Z0-9<]{39})";

        internal override IEnumerable<FieldType> FieldTypes =>
        [
            FieldType.DocumentType,
            FieldType.CountryCode,
            FieldType.PrimaryIdentifier,
        ];
    }
}
