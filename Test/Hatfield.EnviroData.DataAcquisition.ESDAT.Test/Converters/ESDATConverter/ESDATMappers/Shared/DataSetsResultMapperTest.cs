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
    class DatasetsResultMapperTest
    {
        [Test]
        public void ScaffoldChemistryTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new DatasetsResultMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var datasetsResult = mapper.Draft(esdatModel);

            Assert.AreEqual(0, datasetsResult.BridgeID);
            Assert.AreEqual(0, datasetsResult.DatasetID);
            Assert.AreEqual(0, datasetsResult.ResultID);
        }
    }
}
