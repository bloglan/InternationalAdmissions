using MRZCodeParser.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser
{
    public abstract class MrzCode
    {
        protected IEnumerable<string> RawLines { get; }

        public abstract CodeType Type { get; }

        public abstract IEnumerable<MrzLine> Lines { get; }

        public IEnumerable<FieldType> FieldTypes => this.Lines.SelectMany(x => x.FieldTypes);

        public string this[FieldType type]
        {
            get
            {
                var fields = this.Fields;
                var targetType = this.ChangeBackwardFieldTypeToCurrent(type);

                if (fields.Fields.All(x => x.Type != targetType))
                {
                    throw new MrzCodeException($"Code {this.Type} does not contain field {type}");
                }

                return fields[targetType].Value;
            }
        }

        protected virtual FieldType ChangeBackwardFieldTypeToCurrent(FieldType type) => type;

        [Obsolete(message: "Will be changed to internal in next version")]
        public FieldsCollection Fields
        {
            get
            {
                var fields = new List<Field>();
                foreach (var line in this.Lines)
                {
                    fields.AddRange(line.Fields.Fields);
                }

                return new FieldsCollection(fields);
            }
        }

        protected MrzCode(IEnumerable<string> lines)
        {
            this.RawLines = lines;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Lines.Select(x => x.Value));
        }

        public static MrzCode Parse(string code)
        {
            var lines = new LineSplitter(code)
                .Split()
                .ToList();
            var type = new CodeTypeDetector(lines).DetectType();

            return type switch
            {
                CodeType.TD1 => new TD1MrzCode(lines),
                CodeType.TD2 => new TD2MrzCode(lines),
                CodeType.TD3 => new TD3MrzCode(lines),
                CodeType.MRVA => new MRVAMrzCode(lines),
                CodeType.MRVB => new MRVBMrzCode(lines),
                _ => new UnknownMrzCode(lines)
            };
        }
    }
}