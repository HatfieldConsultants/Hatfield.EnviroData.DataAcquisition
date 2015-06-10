using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class MeasurementResultValueMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new MeasurementResultValueMapper(mockDbContext, duplicateChecker);

            var sample = new SampleFileData();
            sample.SampledDateTime = DateTime.Now;
            var measurementResultValue = mapper.Scaffold(sample);

            Assert.AreEqual(0, measurementResultValue.ValueID);
            Assert.AreEqual(0, measurementResultValue.ResultID);
            Assert.AreEqual(0, measurementResultValue.DataValue);
            Assert.AreEqual(sample.SampledDateTime, measurementResultValue.ValueDateTime);
            Assert.AreEqual(0, measurementResultValue.ValueDateTimeUTCOffset);
            Assert.AreEqual(0, measurementResultValue.ValueID);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new MeasurementResultValueMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            chemistry.Result = 101;
            chemistry.AnalysedDate = DateTime.Now;
            var measurementResultValue = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, measurementResultValue.ValueID);
            Assert.AreEqual(0, measurementResultValue.ResultID);
            Assert.AreEqual(chemistry.Result, measurementResultValue.DataValue);
            Assert.AreEqual(chemistry.AnalysedDate, measurementResultValue.ValueDateTime);
            Assert.AreEqual(0, measurementResultValue.ValueDateTimeUTCOffset);
            Assert.AreEqual(0, measurementResultValue.ValueID);
        }
    }
}
