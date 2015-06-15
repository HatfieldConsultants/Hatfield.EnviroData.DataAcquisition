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
    class MethodMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new MethodMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var esdatModel = new ESDATModel();
            var method = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, method.MethodID);
            Assert.AreEqual("fieldActivity", method.MethodTypeCV);
            Assert.AreEqual(string.Empty, method.MethodCode);
            Assert.AreEqual("Sample Collection", method.MethodName);
            Assert.AreEqual(null, method.MethodDescription);
            Assert.AreEqual(null, method.MethodLink);
            Assert.AreEqual(null, method.OrganizationID);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new MethodMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var chemistry = new ChemistryFileData();
            var method = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, method.MethodID);
            Assert.AreEqual("specimenAnalysis", method.MethodTypeCV);
            Assert.AreEqual(string.Empty, method.MethodCode);
            Assert.AreEqual(null, method.MethodName);
            Assert.AreEqual(null, method.MethodDescription);
            Assert.AreEqual(null, method.MethodLink);
            Assert.AreEqual(null, method.OrganizationID);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new MethodMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var sampleEntity = new Method();
            sampleEntity.MethodID = 101;
            sampleEntity.MethodTypeCV = "Kyle";
            sampleEntity.MethodName = "Garsuta";

            var sampleList = new List<Method>() { sampleEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Method>()).Returns(sampleList);

            var entity = mapper.GetDuplicate(sampleEntity);

            Assert.AreEqual(101, entity.MethodID);
            Assert.AreEqual("Kyle", entity.MethodTypeCV);
            Assert.AreEqual("Garsuta", entity.MethodName);
        }
    }
}
