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
    class UnitMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new UnitMapper(mockDbContext, duplicateChecker);

            var sample = new SampleFileData();
            var unit = mapper.Scaffold(sample);

            Assert.AreEqual(0, unit.UnitsID);
            Assert.AreEqual(string.Empty, unit.UnitsTypeCV);
            Assert.AreEqual(string.Empty, unit.UnitsAbbreviation);
            Assert.AreEqual(string.Empty, unit.UnitsName);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new UnitMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            chemistry.ResultUnit = "Unit";
            var unit = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, unit.UnitsID);
            Assert.AreEqual("Unit", unit.UnitsTypeCV);
            Assert.AreEqual("Un", unit.UnitsAbbreviation);
            Assert.AreEqual("Unit", unit.UnitsName);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ScaffoldInvalidChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new UnitMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            chemistry.ResultUnit = null;
            var unit = mapper.Scaffold(chemistry);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new UnitMapper(mockDbContext, duplicateChecker);

            var testUnit = new Unit();
            testUnit.UnitsID = 102;
            testUnit.UnitsTypeCV = "mg/L";
            testUnit.UnitsAbbreviation = "mg";
            testUnit.UnitsName = "mg/L";

            var unitList = new List<Unit>() { testUnit }.AsQueryable();
            mockDb.Setup(x => x.Query<Unit>()).Returns(unitList);

            var unit = mapper.CheckDuplicate(testUnit);

            Assert.AreEqual(102, unit.UnitsID);
            Assert.AreEqual("mg/L", unit.UnitsTypeCV);
            Assert.AreEqual("mg", unit.UnitsAbbreviation);
            Assert.AreEqual("mg/L", unit.UnitsName);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new UnitMapper(mockDbContext, duplicateChecker);

            var result1 = new Result();
            var result2 = new Result();
            var entity = new Unit();
            entity = mapper.Link(entity, result1);

            Assert.IsTrue(entity.Results.Contains(result1));
            Assert.IsFalse(entity.Results.Contains(result2));
        }
    }
}
