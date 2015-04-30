using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueParsers;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class IntValueParserTest
    {
        [Test]
        [TestCase("1", 1)]
        [TestCase("100", 100)]
        [TestCase(null, 0)]        
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var intValueParser = new IntValueParser();

            var parsedValue = intValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        public void AssertParseFailTest()
        {
            var intValueParser = new IntValueParser();
            
            Assert.Throws(typeof(FormatException), () => intValueParser.Parse("Hello World"), "Can not parse value to integer");
        }
    }
}
