using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class Td1FirstLine : MrzLine
    {
        internal Td1FirstLine(string value) : base(value)
        {
        }

        protected override string Pattern => "([A|C|I][A-Z0-9<]{1})([A-Z<]{3})([A-Z0-9<]{9})([0-9]{1})([A-Z0-9<]{15})";

        internal override IEnumerable<FieldType> FieldTypes =>
        [
            FieldType.DocumentType,
            FieldType.CountryCode,
            FieldType.DocumentNumber,
            FieldType.DocumentNumberCheckDigit,
            FieldType.OptionalData1
        ];
    }
}
