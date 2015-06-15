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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new PersonMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var affiliation = new Affiliation();
            var person = mapper.Scaffold();

            Assert.AreEqual(0, person.PersonID);
            Assert.AreEqual(string.Empty, person.PersonFirstName);
            Assert.AreEqual(null, person.PersonMiddleName);
            Assert.AreEqual(string.Empty, person.PersonLastName);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new PersonMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var sampleEntity = new Person();
            sampleEntity.PersonID = 101;
            sampleEntity.PersonFirstName = "Kyle";
            sampleEntity.PersonLastName = "Garsuta";

            var sampleList = new List<Person>() { sampleEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Person>()).Returns(sampleList);

            var entity = mapper.GetDuplicate(sampleEntity);

            Assert.AreEqual(sampleEntity.PersonID, entity.PersonID);
            Assert.AreEqual("Kyle", entity.PersonFirstName);
            Assert.AreEqual("Garsuta", entity.PersonLastName);
        }
    }
}
