using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ChemistryMeasurementResultMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();

            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new ChemistryMeasurementResultMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var measurementResult = mapper.Scaffold(esdatModel, chemistry);

            Assert.AreEqual(0, measurementResult.ResultID);
            Assert.AreEqual(null, measurementResult.XLocation);
            Assert.AreEqual(null, measurementResult.XLocationUnitsID);
            Assert.AreEqual(null, measurementResult.YLocation);
            Assert.AreEqual(null, measurementResult.YLocationUnitsID);
            Assert.AreEqual(null, measurementResult.ZLocation);
            Assert.AreEqual(null, measurementResult.ZLocationUnitsID);
            Assert.AreEqual(null, measurementResult.SpatialReferenceID);
            Assert.AreEqual("Not censored", measurementResult.CensorCodeCV);
            Assert.AreEqual("Unknown", measurementResult.QualityCodeCV);
            Assert.AreEqual("Unknown", measurementResult.AggregationStatisticCV);
            Assert.AreEqual(0, measurementResult.TimeAggregationInterval);
            Assert.AreEqual(0, measurementResult.TimeAggregationIntervalUnitsID);
        }
    }
}
