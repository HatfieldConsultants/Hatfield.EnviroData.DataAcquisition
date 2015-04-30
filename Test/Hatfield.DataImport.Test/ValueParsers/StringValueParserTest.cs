using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueParsers;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class StringValueParserTest
    {
        [Test]
        [TestCase("1.5", "1.5")]
        [TestCase("100.5", "100.5")]
        [TestCase("Test", "Test")]
        [TestCase(" Test ", "Test")]
        [TestCase(null, null)]
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var stringValueParser = new StringValueParser();

            var parsedValue = stringValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }
    }
}
