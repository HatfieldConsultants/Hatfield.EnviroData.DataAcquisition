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
    class SampleCollectionUnitMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var mapper = new SampleCollectionUnitMapper(parameters);

            var unit = mapper.Scaffold();

            Assert.AreEqual(0, unit.UnitsID);
            Assert.AreEqual("dimensionless", unit.UnitsTypeCV);
            Assert.AreEqual("di", unit.UnitsAbbreviation);
            Assert.AreEqual("dimensionless", unit.UnitsName);
        }
    }
}
