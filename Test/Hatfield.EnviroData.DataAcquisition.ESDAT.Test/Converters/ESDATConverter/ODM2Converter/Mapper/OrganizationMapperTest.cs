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
    class OrganizationMapperTest
    {
        [Test]
        public void Scaffold()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new OrganizationMapper(mockDbContext, duplicateChecker);

            var esdatModel = new ESDATModel();
            esdatModel.LabName = "XYZ Labs";
            var organization = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, organization.OrganizationID);
            Assert.AreEqual("Company", organization.OrganizationTypeCV);
            Assert.AreEqual(esdatModel.LabName.Substring(0, 3), organization.OrganizationCode);
            Assert.AreEqual(esdatModel.LabName, organization.OrganizationName);
            Assert.AreEqual(null, organization.OrganizationDescription);
            Assert.AreEqual(null, organization.OrganizationLink);
            Assert.AreEqual(null, organization.ParentOrganizationID);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new OrganizationMapper(mockDbContext, duplicateChecker);

            var sampleEntity = new Organization();
            sampleEntity.OrganizationID = 101;
            sampleEntity.OrganizationName = "Kyle";

            var sampleList = new List<Organization>() { sampleEntity }.AsQueryable();
            mockDb.Setup(x => x.Query<Organization>()).Returns(sampleList);

            var entity = mapper.CheckDuplicate(sampleEntity);

            Assert.AreEqual(101, entity.OrganizationID);
            Assert.AreEqual("Kyle", entity.OrganizationName);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new OrganizationMapper(mockDbContext, duplicateChecker);

            var entity1 = new Affiliation();
            var entity2 = new Affiliation();
            var entity = new Organization();
            entity = mapper.Link(entity, entity1);

            Assert.IsTrue(entity.Affiliations.Contains(entity1));
            Assert.IsFalse(entity.Affiliations.Contains(entity2));
        }
    }
}
