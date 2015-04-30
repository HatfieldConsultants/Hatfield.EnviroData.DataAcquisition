using Hatfield.EnviroData.DataImport.ValueParsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class BooleanValueParserTest
    {
        static object[] testCases = new object[] { 
            new object[]{
                "true",
                true
            },
            new object[]{
                "false",
                false
            }
        };

        [Test]
        [TestCaseSource("testCases")]
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var booleanValueParser = new BooleanValueParser();

            var parsedValue = booleanValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException), "Can not parse null value to datetime")]
        [TestCase("Hello World", typeof(FormatException), "Can not parse value to datetime")]
        public void AssertParseFailTest(string valueToParse, Type expectionType, string exceptionMessage)
        {
            var booleanValueParser = new BooleanValueParser();

            Assert.Throws(expectionType, () => booleanValueParser.Parse(valueToParse), exceptionMessage);
        }
    }
}
