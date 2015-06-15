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
    class VariableMapperTest
    {
        [Test]
        public void MapSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new VariableMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var testEntity = new Variable();
            testEntity.VariableID = 101;
            testEntity.VariableTypeCV = "Sample";
            testEntity.VariableCode = string.Empty;
            testEntity.VariableNameCV = string.Empty;
            testEntity.SpeciationCV = "notApplicable";
            testEntity.NoDataValue = -9999;

            var entityList = new List<Variable>() { testEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Variable>()).Returns(entityList);

            var sample = new SampleFileData();
            var result = new Result();

            var variable = mapper.Map(sample);

            Assert.AreEqual(101, variable.VariableID);
            Assert.AreEqual("Sample", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }

        [Test]
        public void MapChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new VariableMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var testEntity = new Variable();
            testEntity.VariableID = 101;
            testEntity.VariableTypeCV = "Chemistry";
            testEntity.VariableCode = string.Empty;
            testEntity.VariableNameCV = string.Empty;
            testEntity.SpeciationCV = "notApplicable";
            testEntity.NoDataValue = -9999;

            var entityList = new List<Variable>() { testEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Variable>()).Returns(entityList);

            var chemistry = new ChemistryFileData();
            var result = new Result();

            var variable = mapper.Map(chemistry);

            Assert.AreEqual(101, variable.VariableID);
            Assert.AreEqual("Chemistry", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }

        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new VariableMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var sample = new SampleFileData();
            var variable = mapper.Scaffold(sample);

            Assert.AreEqual(0, variable.VariableID);
            Assert.AreEqual("Sample", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new VariableMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var chemistry = new ChemistryFileData();
            chemistry.OriginalChemName = "XYZ";
            var variable = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, variable.VariableID);
            Assert.AreEqual("Chemistry", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual("XYZ", variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new VariableMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var testVariable = new Variable();
            testVariable.VariableID = 101;
            testVariable.VariableTypeCV = "Sample";
            testVariable.VariableCode = string.Empty;
            testVariable.VariableNameCV = string.Empty;
            testVariable.SpeciationCV = "notApplicable";
            testVariable.NoDataValue = -9999;

            var variableList = new List<Variable>() { testVariable }.AsQueryable();
            mockDb.Setup(x => x.Query<Variable>()).Returns(variableList);

            var variable = mapper.GetDuplicate(testVariable);

            Assert.AreEqual(101, variable.VariableID);
            Assert.AreEqual("Sample", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }
    }
}
