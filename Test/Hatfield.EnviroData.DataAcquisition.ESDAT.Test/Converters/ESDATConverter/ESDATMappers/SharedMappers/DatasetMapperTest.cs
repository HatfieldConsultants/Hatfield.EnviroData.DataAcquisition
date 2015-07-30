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
    class DatasetMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new DatasetMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var datasetsResult = new DatasetsResult();
            var dataSet = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.DefaultDatasetTypeCV, dataSet.DatasetTypeCV);
            Assert.AreEqual(esdatModel.LabRequestId.ToString(), dataSet.DatasetCode);
            Assert.AreEqual(String.Format("{0}: {1} ({2})", esdatModel.LabName, esdatModel.LabRequestId.ToString(), esdatModel.DateReported), dataSet.DatasetTitle);
            Assert.AreEqual(string.Empty, dataSet.DatasetAbstract);
        }
    }
}
