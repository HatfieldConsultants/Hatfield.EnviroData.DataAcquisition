using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ProcessingLevelConverterTest
    {
        [Test]
        public void ProcessingLevelTest()
        {
            var result = new Result();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var processingLevelConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelConverter;
            var processingLevel = processingLevelConverter.Convert(result);

            Assert.AreEqual(0, processingLevel.ProcessingLevelID);
            Assert.AreEqual(string.Empty, processingLevel.ProcessingLevelCode);
            Assert.AreEqual(null, processingLevel.Definition);
            Assert.AreEqual(null, processingLevel.Explanation);
        }
    }
}
