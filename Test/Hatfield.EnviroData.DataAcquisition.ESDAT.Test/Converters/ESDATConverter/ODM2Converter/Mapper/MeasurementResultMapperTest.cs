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
    class MeasurementResultMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new MeasurementResultMapper(mockDbContext, duplicateChecker);

            var sample = new SampleFileData();
            var measurementResult = mapper.Scaffold(sample);

            Assert.AreEqual(0, measurementResult.ResultID);
            Assert.AreEqual(null, measurementResult.XLocation);
            Assert.AreEqual(null, measurementResult.XLocationUnitsID);
            Assert.AreEqual(null, measurementResult.YLocation);
            Assert.AreEqual(null, measurementResult.YLocationUnitsID);
            Assert.AreEqual(null, measurementResult.ZLocation);
            Assert.AreEqual(null, measurementResult.ZLocationUnitsID);
            Assert.AreEqual(null, measurementResult.SpatialReferenceID);
            Assert.AreEqual("notCensored", measurementResult.CensorCodeCV);
            Assert.AreEqual("unknown", measurementResult.QualityCodeCV);
            Assert.AreEqual("unknown", measurementResult.AggregationStatisticCV);
            Assert.AreEqual(0, measurementResult.TimeAggregationInterval);
            Assert.AreEqual(0, measurementResult.TimeAggregationIntervalUnitsID);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new MeasurementResultMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            var measurementResult = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, measurementResult.ResultID);
            Assert.AreEqual(null, measurementResult.XLocation);
            Assert.AreEqual(null, measurementResult.XLocationUnitsID);
            Assert.AreEqual(null, measurementResult.YLocation);
            Assert.AreEqual(null, measurementResult.YLocationUnitsID);
            Assert.AreEqual(null, measurementResult.ZLocation);
            Assert.AreEqual(null, measurementResult.ZLocationUnitsID);
            Assert.AreEqual(null, measurementResult.SpatialReferenceID);
            Assert.AreEqual("notCensored", measurementResult.CensorCodeCV);
            Assert.AreEqual("unknown", measurementResult.QualityCodeCV);
            Assert.AreEqual("unknown", measurementResult.AggregationStatisticCV);
            Assert.AreEqual(0, measurementResult.TimeAggregationInterval);
            Assert.AreEqual(0, measurementResult.TimeAggregationIntervalUnitsID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new MeasurementResultMapper(mockDbContext, duplicateChecker);

            var entity1 = new MeasurementResultValue();
            var entity2 = new MeasurementResultValue();
            var entity3 = new Unit();
            var entity4 = new Unit();
            var entity = new MeasurementResult();
            entity = mapper.Link(entity, entity1, entity3);

            Assert.IsTrue(entity.MeasurementResultValues.Contains(entity1));
            Assert.IsFalse(entity.MeasurementResultValues.Contains(entity2));
            Assert.AreEqual(entity3, entity.Unit);
            Assert.AreNotEqual(entity4, entity.Unit);
        }
    }
}
