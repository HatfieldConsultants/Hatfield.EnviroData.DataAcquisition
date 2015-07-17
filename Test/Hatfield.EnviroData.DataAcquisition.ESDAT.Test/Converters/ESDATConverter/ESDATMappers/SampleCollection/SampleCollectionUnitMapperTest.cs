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
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new SampleCollectionUnitMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var unit = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, unit.UnitsID);
            Assert.AreEqual("Dimensionless", unit.UnitsTypeCV);
            Assert.AreEqual("Di", unit.UnitsAbbreviation);
            Assert.AreEqual("Dimensionless", unit.UnitsName);
        }
    }
}
