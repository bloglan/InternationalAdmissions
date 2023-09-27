using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class MRVBMrzCode : MrzCode
    {
        internal MRVBMrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.MRVB;

        public override IEnumerable<MrzLine> Lines => new MrzLine[]
        {
            new MRVBFirstLine(this.RawLines.First()),
            new MRVBSecondLine(this.RawLines.Last())
        };

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