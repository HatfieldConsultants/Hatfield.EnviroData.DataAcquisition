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
    class SamplingFeatureSamplingFeatureMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var mapper = new SampleCollectionSamplingFeatureMapper(parameters);

            var samplingFeature = mapper.Scaffold();

            Assert.AreEqual(0, samplingFeature.SamplingFeatureID);
            Assert.AreEqual("Site", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
        }
    }
}
