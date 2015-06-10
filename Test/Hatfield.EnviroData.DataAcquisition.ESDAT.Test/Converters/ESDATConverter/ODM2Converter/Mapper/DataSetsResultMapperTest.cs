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
    class DataSetsResultMapperTest
    {
        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new DataSetsResultMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            var datasetsResult = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, datasetsResult.BridgeID);
            Assert.AreEqual(0, datasetsResult.DataSetID);
            Assert.AreEqual(0, datasetsResult.ResultID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new DataSetsResultMapper(mockDbContext, duplicateChecker);

            var entity1 = new DataSet();
            var entity2 = new DataSet();
            var entity3 = new Result();
            var entity4 = new Result();
            var entity = new DataSetsResult();

            entity = mapper.Link(entity, entity1, entity3);

            Assert.AreEqual(entity1, entity.DataSet);
            Assert.AreNotEqual(entity2, entity.DataSet);
            Assert.AreEqual(entity3, entity.Result);
            Assert.AreNotEqual(entity4, entity.Result);
        }
    }
}
