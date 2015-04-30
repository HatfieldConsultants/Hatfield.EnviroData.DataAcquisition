using Hatfield.EnviroData.DataImport.ValueParsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class DecimalValueParserTest
    {
        static object[] testCases = new object[] { 
            new object[]{
                "1234.34345345345",
                1234.34345345345m
            },
            new object[]{
                "444.66",
                444.66m
            },
            new object[]{
                null,
                0.0
            }
        };

        [Test]
        [TestCaseSource("testCases")]
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var decimalValueParser = new DecimalValueParser();

            var parsedValue = decimalValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        [TestCase("Hello World", typeof(FormatException), "Can not parse value to datetime")]
        public void AssertParseFailTest(string valueToParse, Type expectionType, string exceptionMessage)
        {
            var decimalValueParser = new DecimalValueParser();

            Assert.Throws(expectionType, () => decimalValueParser.Parse(valueToParse), exceptionMessage);
        }
    }
}
