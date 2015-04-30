using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueParsers;

namespace Hatfield.EnviroData.DataImport.Test.ValueParsers
{
    [TestFixture]
    public class DateTimeValueParserTest
    {
          static object[] testCases = new object[] { 
            new object[]{
                "2014-01-05",
                new DateTime(2014, 1, 5)
            },
            new object[]{
                "2013-12-12 13:30:00",
                new DateTime(2013, 12, 12, 13, 30, 0)
            },
            new object[]{
                "2013-12-13 11:15:00",
                new DateTime(2013, 12, 13, 11, 15, 0)
            }
        };

        [Test]
        [TestCaseSource("testCases")]        
        public void AssertParseTest(object valueToParse, object expectedParsedValue)
        {
            var dateTimeValueParser = new DateTimeValueParser();

            var parsedValue = dateTimeValueParser.Parse(valueToParse);

            Assert.AreEqual(expectedParsedValue, parsedValue);
        }

        [Test]
        [TestCase(null, typeof(ArgumentNullException), "Can not parse null value to datetime")]
        [TestCase("Hello World", typeof(FormatException), "Can not parse value to datetime")]
        public void AssertParseFailTest(string valueToParse, Type expectionType, string exceptionMessage)
        {
            var dateTimeValueParser = new DateTimeValueParser();

            Assert.Throws(expectionType, () => dateTimeValueParser.Parse(valueToParse), exceptionMessage);
        }
    }
}
