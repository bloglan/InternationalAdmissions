using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser.CodeTypes
{
    internal class Td1MrzCode : MrzCode
    {
        internal Td1MrzCode(IEnumerable<string> lines) : base(lines)
        {
        }

        public override CodeType Type => CodeType.Td1;

        public override IEnumerable<MrzLine> Lines =>
        [
            new Td1FirstLine(RawLines.First()),
            new Td1SecondLine(RawLines.ElementAt(1)),
            new Td1ThirdLine(RawLines.Last())
        ];
    }
}