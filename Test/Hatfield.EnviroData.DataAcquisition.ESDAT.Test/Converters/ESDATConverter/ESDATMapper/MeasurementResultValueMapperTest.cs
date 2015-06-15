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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new MeasurementResultValueMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new MeasurementResultValueMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

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
