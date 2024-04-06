using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class MrvbMrzCode : MrzCode
    {
        internal MrvbMrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.Mrvb;

        public override IEnumerable<MrzLine> Lines =>
        [
            new MrvbFirstLine(RawLines.First()),
            new MrvbSecondLine(RawLines.Last())
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