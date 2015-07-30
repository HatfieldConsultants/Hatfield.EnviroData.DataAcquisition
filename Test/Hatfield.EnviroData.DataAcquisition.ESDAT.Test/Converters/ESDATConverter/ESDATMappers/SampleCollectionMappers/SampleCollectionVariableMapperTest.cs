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
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new SampleCollectionVariableMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var variable = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.DefaultVariableTypeCVSampleCollection, variable.VariableTypeCV);
            Assert.AreEqual(defaultValueProvider.DefaultVariableCode, variable.VariableCode);
            Assert.AreEqual(defaultValueProvider.DefaultVariableNameCV, variable.VariableNameCV);
            Assert.AreEqual(defaultValueProvider.DefaultVariableSpeciationCV, variable.SpeciationCV);
            Assert.AreEqual(defaultValueProvider.DefaultVariableNoDataValue, variable.NoDataValue);
        }
    }
}
