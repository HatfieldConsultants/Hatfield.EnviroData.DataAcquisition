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
    class PersonMapperTest
    {
        [Test]
        public void Scaffold()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new PersonMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var affiliation = new Affiliation();
            var person = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.DefaultPersonFirstName, person.PersonFirstName);
            Assert.AreEqual(defaultValueProvider.DefaultPersonMiddleName, person.PersonMiddleName);
            Assert.AreEqual(defaultValueProvider.DefaultPersonLastName, person.PersonLastName);
        }
    }
}
