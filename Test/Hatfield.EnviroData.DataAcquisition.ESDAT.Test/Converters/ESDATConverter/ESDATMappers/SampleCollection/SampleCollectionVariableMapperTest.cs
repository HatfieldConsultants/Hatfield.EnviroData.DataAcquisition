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
    class SampleCollectionVariableMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.DateReported = DateTime.Now;

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var mapper = new SampleCollectionVariableMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData);

            var variable = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, variable.VariableID);
            Assert.AreEqual("Unknown", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("Unknown", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
        }
    }
}
