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
    class DatasetMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var mapper = new DatasetMapper(parameters);

            var datasetsResult = new DatasetsResult();
            var dataSet = mapper.Scaffold();

            Assert.AreEqual(0, dataSet.DatasetID);
            Assert.AreEqual("other", dataSet.DatasetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DatasetCode);
            Assert.AreEqual(string.Empty, dataSet.DatasetTitle);
            Assert.AreEqual(string.Empty, dataSet.DatasetAbstract);
        }
    }
}
