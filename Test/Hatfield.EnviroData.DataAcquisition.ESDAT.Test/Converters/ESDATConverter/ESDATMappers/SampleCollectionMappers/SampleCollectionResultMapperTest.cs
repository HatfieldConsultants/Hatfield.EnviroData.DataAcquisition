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
    class SampleCollectionResultMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();
            var sample = new SampleFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            //duplicateChecker.SampleFileData = sample;
            var results = new List<IResult>();
            var mapper = new SampleCollectionResultMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            mapper.Sample = sample;
            var result = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.ResultTypeCVSampleCollection, result.ResultTypeCV);
            Assert.AreEqual(sample.SampledDateTime, result.ResultDateTime);
            Assert.AreEqual(defaultValueProvider.ResultSampledMediumCVSampleCollection, result.SampledMediumCV);
            Assert.AreEqual(1, result.ValueCount);
        }
    }
}
