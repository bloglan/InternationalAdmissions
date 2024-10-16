using System.Linq;
using Xunit;

namespace MRZCodeParser.Tests
{
    public class MrvaMrzCodeTest
    {
        [Fact]
        public void CodeFieldsTest()
        {
            var target = MrzCode.Parse(MrzSamples.Mrva);

            Assert.Equal(DocumentType.V.ToString(), target[FieldType.DocumentType]);
            Assert.Equal("UTO", target[FieldType.CountryCode]);
            Assert.Equal("ERIKSSON, ANNA MARIA", target[FieldType.PrimaryIdentifier]);
            Assert.Equal("L8988901C", target[FieldType.DocumentNumber]);
            Assert.Equal("4", target[FieldType.DocumentNumberCheckDigit]);
            Assert.Equal("XXX", target[FieldType.Nationality]);
            Assert.Equal("400907", target[FieldType.BirthDate]);
            Assert.Equal("8", target[FieldType.BirthDateCheckDigit]);
            Assert.Equal("F", target[FieldType.Sex]);
            Assert.Equal("961210", target[FieldType.ExpiryDate]);
            Assert.Equal("9", target[FieldType.ExpiryDateCheckDigit]);
            Assert.Equal("6ZE184226B", target[FieldType.OptionalData]);
        }

        [Fact]
        public void CodeFieldsTest_BackwardCompatibility()
        {
            var target = MrzCode.Parse(MrzSamples.Mrva);

            Assert.Equal(target[FieldType.OptionalData], target[FieldType.OptionalData2]);
        }

        [Fact]
        public void FieldTypeCollectionTest()
        {
            var target = MrzCode.Parse(MrzSamples.Mrva);

            var expected = new[]
            {
                FieldType.DocumentType,
                FieldType.CountryCode,
                FieldType.PrimaryIdentifier,
                FieldType.DocumentNumber,
                FieldType.DocumentNumberCheckDigit,
                FieldType.Nationality,
                FieldType.BirthDate,
                FieldType.BirthDateCheckDigit,
                FieldType.Sex,
                FieldType.ExpiryDate,
                FieldType.ExpiryDateCheckDigit,
                FieldType.OptionalData
            };

            var actual = target.FieldTypes.ToList();

            Assert.Equal(expected.Length, actual.Count);
            Assert.Equal(expected, actual);
        }
    }
}