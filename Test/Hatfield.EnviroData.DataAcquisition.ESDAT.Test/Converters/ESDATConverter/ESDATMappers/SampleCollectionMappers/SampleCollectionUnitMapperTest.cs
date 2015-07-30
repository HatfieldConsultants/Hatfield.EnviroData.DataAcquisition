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
    class SampleCollectionUnitMapperTest
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
            var mapper = new SampleCollectionUnitMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var unit = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.DefaultUnitsTypeCVSampleCollection, unit.UnitsTypeCV);
            Assert.AreEqual(mapper.AbbereviateUnit(defaultValueProvider.DefaultUnitsTypeCVSampleCollection), unit.UnitsAbbreviation);
            Assert.AreEqual(defaultValueProvider.DefaultUnitsTypeCVSampleCollection, unit.UnitsName);
        }
    }
}
