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
    class SampleCollectionActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.DateReported = DateTime.Now;

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var SampleCollectionFactory = new ESDATSampleCollectionMapperFactory(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);
            var chemistryFactory = new ESDATChemistryMapperFactory(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);
            var mapper = new SampleCollectionActionMapper(duplicateChecker, SampleCollectionFactory, defaultValueProvider, chemistryFactory, wayToHandleNewData, results);

            var action = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.ActionTypeCVSampleCollection, action.ActionTypeCV);
            Assert.AreEqual(esdatModel.DateReported, action.BeginDateTime);
        }
    }
}
