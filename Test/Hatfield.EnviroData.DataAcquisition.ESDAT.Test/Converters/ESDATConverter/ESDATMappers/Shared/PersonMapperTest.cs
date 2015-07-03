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
    class PersonMapperTest
    {
        [Test]
        public void Scaffold()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var mapper = new PersonMapper(parameters);

            var affiliation = new Affiliation();
            var person = mapper.Scaffold();

            Assert.AreEqual(0, person.PersonID);
            Assert.AreEqual(string.Empty, person.PersonFirstName);
            Assert.AreEqual(string.Empty, person.PersonMiddleName);
            Assert.AreEqual(string.Empty, person.PersonLastName);
        }
    }
}
