using Hatfield.EnviroData.DataImport.ValueParsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class NullableValueTypesTest
    {
        static object[] testCases = new object[] { 
            new object[]{
                null,
                null
            }         
        };

        [Test]
        [TestCaseSource("testCases")]
        public void AssertNullableValueTypesParseTest(object valueToParse, object expectedParsedValue)
        {
            var decimalValueParser = new NullableDecimalValueParser();
            var parsedValue = decimalValueParser.Parse(valueToParse);
            var doubleValueParser = new NullableDoubleValueParser();
            var doubleParsedValue = doubleValueParser.Parse(valueToParse);
            var booleanValueParser = new NullableBooleanValueParser();
            var boolParsedValue = booleanValueParser.Parse(valueToParse);
            var dateTimeValueParser = new NullableDateTimeValueParser();
            var dateTimeParsedValue = dateTimeValueParser.Parse(valueToParse);
            var intParser = new NullableIntValueParser();
            var intParsedValue = intParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, intParsedValue);
            Assert.AreEqual(expectedParsedValue, dateTimeParsedValue);
            Assert.AreEqual(expectedParsedValue, doubleParsedValue);
            Assert.AreEqual(expectedParsedValue, parsedValue);
            Assert.AreEqual(expectedParsedValue, boolParsedValue);
        }

        [Test]
        //[TestCase(null, typeof(ArgumentNullException))]
        [TestCase("Hello World", typeof(FormatException))]
        public void AssertNullableIntParseFailTest(string valueToParse, Type expectionType)
        {
            var intValueParser = new NullableIntValueParser();
            var dateTimeValueParser = new NullableDateTimeValueParser();
            var booleanValueParser = new NullableBooleanValueParser();
            var doubleValueParser = new NullableDoubleValueParser();
            var decimalValueParser = new NullableDecimalValueParser();
            Assert.Throws(expectionType, () => intValueParser.Parse(valueToParse));
            Assert.Throws(expectionType, () => dateTimeValueParser.Parse(valueToParse));
            Assert.Throws(expectionType, () => booleanValueParser.Parse(valueToParse));
            Assert.Throws(expectionType, () => doubleValueParser.Parse(valueToParse));
            Assert.Throws(expectionType, () => decimalValueParser.Parse(valueToParse));
        }
    }
}
