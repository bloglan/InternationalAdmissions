using System;
using System.Collections.Generic;

namespace MRZCodeParser
{
    internal class LineSplitter
    {
        private readonly string _input;

        internal LineSplitter(string input)
        {
            this._input = input ?? throw new ArgumentNullException(nameof(input));
        }

        internal IEnumerable<string> Split()
        {
            var separator = _input.Contains("\r\n") ? "\r\n" : "\n";
            return _input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}