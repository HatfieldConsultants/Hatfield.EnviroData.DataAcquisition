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
    class ChemistryMeasurementResultValueMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.Result = 101;
            chemistry.AnalysedDate = DateTime.Now;

            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new ChemistryMeasurementResultValueMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var measurementResultValue = mapper.Draft(esdatModel, chemistry);

            Assert.AreEqual(0, measurementResultValue.ValueID);
            Assert.AreEqual(0, measurementResultValue.ResultID);
            Assert.AreEqual(chemistry.Result, measurementResultValue.DataValue);
            Assert.AreEqual(chemistry.AnalysedDate, measurementResultValue.ValueDateTime);
            Assert.AreEqual(0, measurementResultValue.ValueDateTimeUTCOffset);
            Assert.AreEqual(0, measurementResultValue.ValueID);
        }
    }
}
