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
    class MeasurementResultValueConverterTest : ODM2ActionConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var sample = new SampleFileData();
            sample.SampledDateTime = DateTime.Now;

            var measurementResultValue = measurementResultValueConverter.Convert(sample);

            Assert.AreEqual(0, measurementResultValue.ValueID);
            Assert.AreEqual(0, measurementResultValue.ResultID);
            Assert.AreEqual(0, measurementResultValue.DataValue);
            Assert.AreEqual(sample.SampledDateTime, measurementResultValue.ValueDateTime);
            Assert.AreEqual(0, measurementResultValue.ValueDateTimeUTCOffset);
            Assert.AreEqual(0, measurementResultValue.ValueID);
        }

        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.Result = 101;
            chemistry.AnalysedDate = DateTime.Now;

            var measurementResultValue = measurementResultValueConverter.Convert(chemistry);

            Assert.AreEqual(0, measurementResultValue.ValueID);
            Assert.AreEqual(0, measurementResultValue.ResultID);
            Assert.AreEqual(chemistry.Result, measurementResultValue.DataValue);
            Assert.AreEqual(chemistry.AnalysedDate, measurementResultValue.ValueDateTime);
            Assert.AreEqual(0, measurementResultValue.ValueDateTimeUTCOffset);
            Assert.AreEqual(0, measurementResultValue.ValueID);
        }
    }
}
