using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser
{
    internal class CodeTypeDetector
    {
        private readonly IEnumerable<string> _lines;

        internal CodeTypeDetector(IEnumerable<string> lines)
        {
            this._lines = lines;
        }

        internal CodeType DetectType()
        {
            CodeType type = _lines.Count() == 3 && _lines.First().Length == 30
                ? CodeType.Td1
                : _lines.First().Length == 44 && _lines.Count() == 2
                    ? _lines.First()[0] == 'P'
                        ? CodeType.Td3
                        : CodeType.Mrva
                    : _lines.First().Length == 36 && _lines.Count() == 2
                        ? _lines.First()[0] == 'V'
                            ? CodeType.Mrvb
                            : CodeType.Td2
                        : CodeType.Unknown;

            return type;
        }
    }
}