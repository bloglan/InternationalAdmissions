using System.Collections.Generic;

namespace MRZCodeParser.CodeTypes
{
    internal class Td2SecondLine : MrzLine
    {
        internal Td2SecondLine(string value) : base(value)
        {
        }

        protected override string Pattern =>
            "([A-Z0-9<]{9})([0-9]{1})([A-Z<]{3})([0-9]{6})([0-9]{1})([M|F|X|<]{1})([0-9]{6})([0-9]{1})([A-Z0-9<]{7})([0-9]{1})";

        internal override IEnumerable<FieldType> FieldTypes =>
        [
            FieldType.DocumentNumber,
            FieldType.DocumentNumberCheckDigit,
            FieldType.Nationality,
            FieldType.BirthDate,
            FieldType.BirthDateCheckDigit,
            FieldType.Sex,
            FieldType.ExpiryDate,
            FieldType.ExpiryDateCheckDigit,
            FieldType.OptionalData,
            FieldType.OverallCheckDigit
        ];
    }
}
