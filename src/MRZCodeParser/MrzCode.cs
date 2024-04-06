using MRZCodeParser.CodeTypes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MRZCodeParser
{
    public abstract class MrzCode(IEnumerable<string> lines)
    {
        protected IEnumerable<string> RawLines { get; } = lines;

        public abstract CodeType Type { get; }

        public abstract IEnumerable<MrzLine> Lines { get; }

        public IEnumerable<FieldType> FieldTypes => Lines.SelectMany(x => x.FieldTypes);

        public string this[FieldType type]
        {
            get
            {
                var fields = Fields;
                var targetType = ChangeBackwardFieldTypeToCurrent(type);

                if (fields.Fields.All(x => x.Type != targetType))
                {
                    throw new MrzCodeException($"Code {Type} does not contain field {type}");
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
                foreach (var line in Lines)
                {
                    fields.AddRange(line.Fields.Fields);
                }

                return new FieldsCollection(fields);
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Lines.Select(x => x.Value));
        }

        public static MrzCode Parse(string code)
        {
            var lines = new LineSplitter(code)
                .Split()
                .ToList();
            var type = new CodeTypeDetector(lines).DetectType();

            return type switch
            {
                CodeType.Td1 => new Td1MrzCode(lines),
                CodeType.Td2 => new Td2MrzCode(lines),
                CodeType.Td3 => new Td3MrzCode(lines),
                CodeType.Mrva => new MrvaMrzCode(lines),
                CodeType.Mrvb => new MrvbMrzCode(lines),
                _ => new UnknownMrzCode(lines)
            };
        }
    }
}