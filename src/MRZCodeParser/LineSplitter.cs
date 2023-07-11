using System;
using System.Collections.Generic;

namespace MRZCodeParser
{
    internal class LineSplitter
    {
        private readonly string input;

        internal LineSplitter(string input)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
        }

        internal IEnumerable<string> Split()
        {
            var separator = this.input.Contains("\r\n") ? "\r\n" : "\n";
            return this.input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}