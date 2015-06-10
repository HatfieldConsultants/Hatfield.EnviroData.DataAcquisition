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
    class AffiliationMapperTest
    {
        [Test]
        public void ScaffoldSampleActionByTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new AffiliationMapper(mockDbContext, duplicateChecker);

            var actionBy = new ActionBy();
            actionBy.BridgeID = 101;
            var affiliation = mapper.Scaffold(actionBy);

            Assert.AreEqual(0, affiliation.AffiliationID);
            Assert.AreEqual(0, affiliation.PersonID);
            Assert.AreEqual(null, affiliation.OrganizationID);
            Assert.AreEqual(null, affiliation.IsPrimaryOrganizationContact);
            Assert.AreEqual(null, affiliation.AffiliationEndDate);
            Assert.AreEqual(null, affiliation.PrimaryPhone);
            Assert.AreEqual(string.Empty, affiliation.PrimaryEmail);
            Assert.AreEqual(null, affiliation.PrimaryAddress);
            Assert.AreEqual(null, affiliation.PersonLink);
        }

        [Test]
        public void ScaffoldChemistryOrganization()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new AffiliationMapper(mockDbContext, duplicateChecker);

            var organization = new Organization();
            var affiliation = mapper.Scaffold(organization);

            Assert.AreEqual(0, affiliation.AffiliationID);
            Assert.AreEqual(0, affiliation.PersonID);
            Assert.AreEqual(0, affiliation.OrganizationID);
            Assert.AreEqual(null, affiliation.IsPrimaryOrganizationContact);
            Assert.AreEqual(null, affiliation.AffiliationEndDate);
            Assert.AreEqual(null, affiliation.PrimaryPhone);
            Assert.AreEqual(string.Empty, affiliation.PrimaryEmail);
            Assert.AreEqual(null, affiliation.PrimaryAddress);
            Assert.AreEqual(null, affiliation.PersonLink);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new AffiliationMapper(mockDbContext, duplicateChecker);

            var organization = new Organization();

            var testEntity = new Affiliation();
            testEntity.AffiliationID = 101;
            testEntity.Organization = organization;
            testEntity.OrganizationID = 102;

            var list = new List<Affiliation>() { testEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Affiliation>()).Returns(list);

            var entity = mapper.CheckDuplicate(testEntity);

            Assert.AreEqual(101, entity.AffiliationID);
            Assert.AreEqual(102, entity.OrganizationID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new AffiliationMapper(mockDbContext, duplicateChecker);

            var entity1 = new Person();
            var entity2 = new Person();
            var entity = new Affiliation();
            entity = mapper.Link(entity, entity1);

            Assert.AreEqual(entity1, entity.Person);
            Assert.AreNotEqual(entity2, entity.Person);
        }
    }
}
