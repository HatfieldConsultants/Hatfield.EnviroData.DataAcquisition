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
    class ProcessingLevelConverterTest : ESDATDataConverterBaseTest
    {
        [Test]
        public void ProcessingLevelTest()
        {
            var processingLevel = processingLevelConverter.Convert(new Result());

            Assert.AreEqual(0, processingLevel.ProcessingLevelID);
            Assert.AreEqual(string.Empty, processingLevel.ProcessingLevelCode);
            Assert.AreEqual(null, processingLevel.Definition);
            Assert.AreEqual(null, processingLevel.Explanation);
        }
    }
}
