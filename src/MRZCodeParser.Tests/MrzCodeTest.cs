using System.Linq;
using Xunit;

namespace MRZCodeParser.Tests
{
    public class MrzCodeTest
    {
        [Theory]
        [InlineData(MrzSamples.Td1, CodeType.Td1)]
        [InlineData(MrzSamples.Td2, CodeType.Td2)]
        [InlineData(MrzSamples.Td3, CodeType.Td3)]
        [InlineData(MrzSamples.Mrva, CodeType.Mrva)]
        [InlineData(MrzSamples.Mrvb, CodeType.Mrvb)]
        [InlineData(MrzSamples.Unknown, CodeType.Unknown)]
        public void CodeTypeDetection(string input, CodeType expected)
        {
            var target = MrzCode.Parse(input);
            Assert.Equal(expected, target.Type);
        }

        [Theory]
        [InlineData(MrzSamples.Td1, 3)]
        [InlineData(MrzSamples.Td2, 2)]
        [InlineData(MrzSamples.Td3, 2)]
        [InlineData(MrzSamples.Mrva, 2)]
        [InlineData(MrzSamples.Mrvb, 2)]
        public void LinesCount(string input, int expected)
        {
            var target = MrzCode.Parse(input);
            Assert.Equal(expected, target.Lines.Count());
        }

        [Theory]
        [InlineData(MrzSamples.Td1)]
        [InlineData(MrzSamples.Td2)]
        [InlineData(MrzSamples.Td3)]
        [InlineData(MrzSamples.Mrva)]
        [InlineData(MrzSamples.Mrvb)]
        public void ToStringReturnsInputLines(string input)
        {
            var target = MrzCode.Parse(input);
            Assert.Equal(input, target.ToString());
        }

        [Theory]
        [InlineData(MrzSamples.Td1, FieldType.PrimaryIdentifier)]
        [InlineData(MrzSamples.Td1, FieldType.OptionalData)]
        [InlineData(MrzSamples.Td1, FieldType.OptionalDataCheckDigit)]
        [InlineData(MrzSamples.Td2, FieldType.Names)]
        [InlineData(MrzSamples.Td2, FieldType.OptionalDataCheckDigit)]
        [InlineData(MrzSamples.Mrvb, FieldType.OverallCheckDigit)]
        public void AccessToInvalidFieldTypeWithException(string input, FieldType invalidType)
        {
            var target = MrzCode.Parse(input);
            Assert.Throws<MrzCodeException>(() => target[invalidType]);
        }

        [Fact]
        public void ExceptionIfCodeDoesNotMatchPattern()
        {
            const string invalidCode = @"V<UTOERIKSSON<<ANNA<MARIA<<<<<<<<<<<<<<<<<<<
L8988901C4XXX4009078R96121096ZE184226B<<<<<<"; // invalid sex value

            Assert.Throws<MrzCodeException>(() => MrzCode.Parse(invalidCode)[FieldType.Sex]);
        }
    }
}