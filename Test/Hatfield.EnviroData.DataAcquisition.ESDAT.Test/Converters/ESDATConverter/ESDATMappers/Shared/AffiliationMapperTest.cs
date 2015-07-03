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
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var mapper = new AffiliationMapper(parameters);

            var affiliation = mapper.Scaffold();

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
    }
}
