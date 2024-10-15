using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class MrvaFirstLine : MrzLine
    {
        internal MrvaFirstLine(string value) : base(value)
        {
        }

        protected override string Pattern => "(V[A-Z0-9<]{1})([A-Z]{3})([A-Z0-9<]{39})";

        internal override IEnumerable<FieldType> FieldTypes =>
        [
            FieldType.DocumentType,
            FieldType.CountryCode,
            FieldType.PrimaryIdentifier,
        ];
    }
}