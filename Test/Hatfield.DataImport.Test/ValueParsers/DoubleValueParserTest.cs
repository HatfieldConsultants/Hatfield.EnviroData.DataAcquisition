using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueParsers;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class DoubleValueParserTest
    {
        [Test]
        [TestCase("1.5", 1.5)]
        [TestCase("100.5", 100.5)]
        [TestCase(null, 0.0)]
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var doubleValueParser = new DoubleValueParser();

            var parsedValue = doubleValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        public void AssertParseFailTest()
        {
            var doubleValueParser = new DoubleValueParser();

            Assert.Throws(typeof(FormatException), () => doubleValueParser.Parse("Hello World"), "Can not parse value to double");
        }
    }
}
