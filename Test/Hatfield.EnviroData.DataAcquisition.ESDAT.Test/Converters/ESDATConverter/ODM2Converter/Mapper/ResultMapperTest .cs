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
    class ResultMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ResultMapper(mockDbContext, duplicateChecker);

            var sample = new SampleFileData();
            sample.MatrixType = "TestMatrix";

            var result = mapper.Scaffold(sample);

            Assert.AreEqual(0, result.ResultID);
            Assert.AreEqual(0, result.FeatureActionID);
            Assert.AreEqual("measurement", result.ResultTypeCV);
            Assert.AreEqual(0, result.VariableID);
            Assert.AreEqual(0, result.UnitsID);
            Assert.AreEqual(0, result.ProcessingLevelID);
            Assert.AreEqual(sample.SampledDateTime, result.ResultDateTime);
            Assert.AreEqual(null, result.ValidDateTime);
            Assert.AreEqual(null, result.ValidDateTimeUTCOffset);
            Assert.AreEqual(null, result.StatusCV);
            Assert.AreEqual(sample.MatrixType, result.SampledMediumCV);
            Assert.AreEqual(1, result.ValueCount);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ResultMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            chemistry.ResultUnit = "Unit";
            chemistry.OriginalChemName = "XYZ";
            var result = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, result.ResultID);
            Assert.AreEqual(0, result.FeatureActionID);
            Assert.AreEqual("measurement", result.ResultTypeCV);
            Assert.AreEqual(0, result.VariableID);
            Assert.AreEqual(0, result.UnitsID);
            Assert.AreEqual(0, result.ProcessingLevelID);
            Assert.AreEqual(chemistry.AnalysedDate, result.ResultDateTime);
            Assert.AreEqual(null, result.ValidDateTime);
            Assert.AreEqual(null, result.ValidDateTimeUTCOffset);
            Assert.AreEqual(null, result.StatusCV);
            Assert.AreEqual("liquidAqueous", result.SampledMediumCV);
            Assert.AreEqual(1, result.ValueCount);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ResultMapper(mockDbContext, duplicateChecker);

            var sampleEntity = new Result();
            sampleEntity.ResultID = 101;

            var sampleList = new List<Result>() { sampleEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Result>()).Returns(sampleList);

            var entity = mapper.CheckDuplicate(sampleEntity);

            Assert.AreEqual(sampleEntity.ResultID, entity.ResultID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ResultMapper(mockDbContext, duplicateChecker);

            var entity = new Result();
            var unit = new Unit();
            var variable = new Variable();
            var dataSetsResult = new DataSetsResult();
            var processingLevel = new ProcessingLevel();
            var measurementResult = new MeasurementResult();
            var entity1 = new Result();
            var unit1 = new Unit();
            var variable1 = new Variable();
            var dataSetsResult1 = new DataSetsResult();
            var processingLevel1 = new ProcessingLevel();
            var measurementResult1 = new MeasurementResult();

            entity = mapper.Link(entity, unit, variable, dataSetsResult, processingLevel, measurementResult);

            Assert.AreEqual(unit, entity.Unit);
            Assert.AreEqual(variable, entity.Variable);
            Assert.IsTrue(entity.DataSetsResults.Contains(dataSetsResult));
            Assert.AreEqual(processingLevel, entity.ProcessingLevel);
            Assert.AreEqual(measurementResult, entity.MeasurementResult);

            Assert.AreNotEqual(unit1, entity.Unit);
            Assert.AreNotEqual(variable1, entity.Variable);
            Assert.IsFalse(entity.DataSetsResults.Contains(dataSetsResult1));
            Assert.AreNotEqual(processingLevel1, entity.ProcessingLevel);
            Assert.AreNotEqual(measurementResult1, entity.MeasurementResult);
        }
    }
}
