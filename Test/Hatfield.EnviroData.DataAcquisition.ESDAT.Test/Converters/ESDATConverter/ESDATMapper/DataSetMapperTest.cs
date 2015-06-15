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
    class DataSetMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new DatasetMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var esdatModel = new ESDATModel();
            esdatModel.SDGID = 101;
            var datasetsResult = new DatasetsResult();
            var dataSet = mapper.Scaffold(datasetsResult, esdatModel);

            Assert.AreEqual(0, dataSet.DatasetID);
            Assert.AreEqual(mapper.ToGuid(esdatModel.SDGID), dataSet.DatasetUUID);
            Assert.AreEqual("other", dataSet.DatasetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DatasetCode);
            Assert.AreEqual(string.Empty, dataSet.DatasetTitle);
            Assert.AreEqual(string.Empty, dataSet.DatasetAbstract);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new DatasetMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var chemistry = new ChemistryFileData();
            var datasetsResult = new DatasetsResult();
            var dataSet = mapper.Scaffold(datasetsResult, chemistry);

            Assert.AreEqual(0, dataSet.DatasetID);
            Assert.AreEqual(mapper.ToGuid(0), dataSet.DatasetUUID);
            Assert.AreEqual("other", dataSet.DatasetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DatasetCode);
            Assert.AreEqual(string.Empty, dataSet.DatasetTitle);
            Assert.AreEqual(string.Empty, dataSet.DatasetAbstract);
        }
    }
}
