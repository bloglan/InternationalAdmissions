using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class MrvaMrzCode : MrzCode
    {
        internal MrvaMrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.Mrva;

        public override IEnumerable<MrzLine> Lines =>
        [
            new MrvaFirstLine(RawLines.First()),
            new MrvaSecondLine(RawLines.Last())
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