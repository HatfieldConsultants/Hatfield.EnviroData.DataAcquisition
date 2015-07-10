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
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var mapper = new PersonMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData);

            var affiliation = new Affiliation();
            var person = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, person.PersonID);
            Assert.AreEqual("Unknown", person.PersonFirstName);
            Assert.AreEqual("Unknown", person.PersonMiddleName);
            Assert.AreEqual("Unknown", person.PersonLastName);
        }
    }
}
