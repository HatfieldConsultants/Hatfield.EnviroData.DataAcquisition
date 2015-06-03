using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ResultConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var sample = new SampleFileData();
            sample.MatrixType = "TestMatrix";

            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var resultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultConverter;
            var result = resultConverter.Convert(sample, converterFactory);

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
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var resultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultConverter;
            var result = resultConverter.Convert(chemistry, converterFactory);

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
