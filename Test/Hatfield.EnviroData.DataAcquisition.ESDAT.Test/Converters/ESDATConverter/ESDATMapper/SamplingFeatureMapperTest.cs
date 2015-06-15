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
    class SamplingFeatureMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new SamplingFeatureMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var samplingFeature = mapper.Scaffold(new ESDATModel());

            Assert.AreEqual(0, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Site", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new SamplingFeatureMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var samplingFeature = mapper.Scaffold(new ChemistryFileData());

            Assert.AreEqual(0, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Specimen", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new SamplingFeatureMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var sampleSamplingFeature = new SamplingFeature();
            sampleSamplingFeature.SamplingFeatureID = 101;
            sampleSamplingFeature.SamplingFeatureTypeCV = "Site";
            sampleSamplingFeature.SamplingFeatureCode = string.Empty;

            var samplingFeatureList = new List<SamplingFeature>() { sampleSamplingFeature }.AsQueryable();
            mockDb.Setup(x => x.Query<SamplingFeature>()).Returns(samplingFeatureList);

            var samplingFeature = mapper.GetDuplicate(sampleSamplingFeature);

            Assert.AreEqual(101, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Site", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }
    }
}
