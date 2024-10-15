using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class Td2MrzCode : MrzCode
    {
        internal Td2MrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.Td2;

        public override IEnumerable<MrzLine> Lines =>
        [
            new Td2FirstLine(RawLines.First()),
            new Td2SecondLine(RawLines.Last())
        ];

        protected override FieldType ChangeBackwardFieldTypeToCurrent(FieldType type)
        {
            return type switch
            {
                FieldType.OptionalData2 => FieldType.OptionalData,
                _ => type
            };
        }
    }
}