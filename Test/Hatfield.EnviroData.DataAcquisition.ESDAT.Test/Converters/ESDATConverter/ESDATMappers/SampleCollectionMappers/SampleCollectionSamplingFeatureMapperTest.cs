using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class SampleCollectionSamplingFeatureMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new SampleCollectionSamplingFeatureMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var samplingFeature = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.DefaultSamplingFeatureTypeCVSampleCollection, samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(defaultValueProvider.DefaultSamplingFeatureCode, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(new Guid(), samplingFeature.SamplingFeatureUUID);
        }
    }
}
