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
    class ChemistrySamplingFeatureMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();

            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new ChemistrySamplingFeatureMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var samplingFeature = mapper.Draft(esdatModel, chemistry);

            Assert.AreEqual(defaultValueProvider.DefaultSamplingFeatureTypeCVChemistry, samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual("Unknown", samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(new Guid(), samplingFeature.SamplingFeatureUUID);
        }
    }
}
