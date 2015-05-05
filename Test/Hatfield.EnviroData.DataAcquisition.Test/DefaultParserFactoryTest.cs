using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.ValueParsers;

namespace Hatfield.EnviroData.DataAcquisition.Test
{
    [TestFixture]
    public class DefaultParserFactoryTest
    {
        [Test]
        [TestCase(typeof(int), typeof(IntValueParser))]
        [TestCase(typeof(double), typeof(DoubleValueParser))]
        [TestCase(typeof(string), typeof(StringValueParser))]
        [TestCase(typeof(DateTime), typeof(DateTimeValueParser))]
        [TestCase(typeof(decimal), typeof(DecimalValueParser))]
        [TestCase(typeof(bool), typeof(BooleanValueParser))]
        [TestCase(typeof(int?), typeof(NullableIntValueParser))]
        [TestCase(typeof(DateTime?), typeof(NullableDateTimeValueParser))]
        [TestCase(typeof(decimal?), typeof(NullableDecimalValueParser))]        
        public void AssertGetValueParserTest(Type valueType, Type expectedValueParserType)
        { 
            var parserFactory = new DefaultParserFactory();
            var actualValueParser = parserFactory.GetValueParser(valueType);

            Assert.NotNull(actualValueParser);
            Assert.AreEqual(expectedValueParserType, actualValueParser.GetType());
        }

        [Test]
        [TestCase(typeof(bool?), ExpectedException = typeof(NotSupportedException))]
        public void AssertGetValueParserFailTest(Type valueType)
        {
            var parserFactory = new DefaultParserFactory();
            var actualValueParser = parserFactory.GetValueParser(valueType);

        }
    }
}
