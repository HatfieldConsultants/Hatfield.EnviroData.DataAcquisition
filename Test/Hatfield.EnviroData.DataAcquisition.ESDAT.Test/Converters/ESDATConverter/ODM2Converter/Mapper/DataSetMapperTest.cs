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
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new DatasetMapper(mockDbContext, duplicateChecker);

            var esdatModel = new ESDATModel();
            esdatModel.SDGID = 101;
            var dataSetsResult = new DataSetsResult();
            var dataSet = mapper.Scaffold(dataSetsResult, esdatModel);

            Assert.AreEqual(0, dataSet.DataSetID);
            Assert.AreEqual(mapper.ToGuid(esdatModel.SDGID), dataSet.DataSetUUID);
            Assert.AreEqual("other", dataSet.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DataSetCode);
            Assert.AreEqual(string.Empty, dataSet.DataSetTitle);
            Assert.AreEqual(string.Empty, dataSet.DataSetAbstract);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new DatasetMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            var dataSetsResult = new DataSetsResult();
            var dataSet = mapper.Scaffold(dataSetsResult, chemistry);

            Assert.AreEqual(0, dataSet.DataSetID);
            Assert.AreEqual(mapper.ToGuid(0), dataSet.DataSetUUID);
            Assert.AreEqual("other", dataSet.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataSet.DataSetCode);
            Assert.AreEqual(string.Empty, dataSet.DataSetTitle);
            Assert.AreEqual(string.Empty, dataSet.DataSetAbstract);
        }
    }
}
