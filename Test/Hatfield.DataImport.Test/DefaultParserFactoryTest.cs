using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.ValueParsers;

namespace Hatfield.EnviroData.DataImport.Test
{
    [TestFixture]
    public class DefaultParserFactoryTest
    {
        [Test]
        [TestCase(typeof(int), typeof(IntValueParser))]
        [TestCase(typeof(double), typeof(DoubleValueParser))]
        [TestCase(typeof(string), typeof(StringValueParser))]
        [TestCase(typeof(DateTime), typeof(DateTimeValueParser))]
        public void AssertGetValueParserTest(Type valueType, Type expectedValueParserType)
        { 
            var parserFactory = new DefaultParserFactory();
            var actualValueParser = parserFactory.GetValueParser(valueType);

            Assert.NotNull(actualValueParser);
            Assert.AreEqual(expectedValueParserType, actualValueParser.GetType());
        }
    }
}
