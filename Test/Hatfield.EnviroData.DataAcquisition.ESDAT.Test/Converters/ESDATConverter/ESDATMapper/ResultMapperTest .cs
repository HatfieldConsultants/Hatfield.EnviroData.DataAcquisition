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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new ResultMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new ResultMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

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
    }
}
