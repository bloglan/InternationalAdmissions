using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser
{
    internal class CodeTypeDetector
    {
        private readonly IEnumerable<string> lines;

        internal CodeTypeDetector(IEnumerable<string> lines)
        {
            this.lines = lines;
        }

        internal CodeType DetectType()
        {
            CodeType type = this.lines.Count() == 3 && this.lines.First().Length == 30
                ? CodeType.TD1
                : this.lines.First().Length == 44 && this.lines.Count() == 2
                    ? this.lines.First()[0] == 'P'
                        ? CodeType.TD3
                        : CodeType.MRVA
                    : this.lines.First().Length == 36 && this.lines.Count() == 2
                        ? this.lines.First()[0] == 'V'
                            ? CodeType.MRVB
                            : CodeType.TD2
                        : CodeType.UNKNOWN;

            return type;
        }
    }
}