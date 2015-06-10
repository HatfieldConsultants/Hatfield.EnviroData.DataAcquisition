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
    class ProcessingLevelMapperTest
    {
        [Test]
        public void Scaffold()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ProcessingLevelMapper(mockDbContext, duplicateChecker);

            var result = new Result();
            var processingLevel = mapper.Scaffold(result);

            Assert.AreEqual(0, processingLevel.ProcessingLevelID);
            Assert.AreEqual(string.Empty, processingLevel.ProcessingLevelCode);
            Assert.AreEqual(null, processingLevel.Definition);
            Assert.AreEqual(null, processingLevel.Explanation);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ProcessingLevelMapper(mockDbContext, duplicateChecker);

            var sampleEntity = new ProcessingLevel();
            sampleEntity.ProcessingLevelID = 101;

            var sampleList = new List<ProcessingLevel>() { sampleEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<ProcessingLevel>()).Returns(sampleList);

            var entity = mapper.CheckDuplicate(sampleEntity);

            Assert.AreEqual(sampleEntity.ProcessingLevelID, entity.ProcessingLevelID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ProcessingLevelMapper(mockDbContext, duplicateChecker);

            var result1 = new Result();
            var result2 = new Result();
            var entity = new ProcessingLevel();
            entity = mapper.Link(entity, result1);

            Assert.IsTrue(entity.Results.Contains(result1));
            Assert.IsFalse(entity.Results.Contains(result2));
        }
    }
}
