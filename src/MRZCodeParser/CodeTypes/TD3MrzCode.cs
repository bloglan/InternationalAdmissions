using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class Td3MrzCode : MrzCode
    {
        internal Td3MrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.Td3;

        public override IEnumerable<MrzLine> Lines =>
        [
            new Td3FirstLine(RawLines.First()),
            new Td3SecondLine(RawLines.Last())
        ];

        protected override FieldType ChangeBackwardFieldTypeToCurrent(FieldType type)
        {
            return type switch
            {
                FieldType.OptionalData2 => FieldType.OptionalData,
                FieldType.OptionalData2CheckDigit => FieldType.OptionalDataCheckDigit,
                _ => type
            };
        }
    }
}