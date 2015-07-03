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
            var esdatModel = new ESDATModel();

            var labName = "XYZ Labs";
            var sample = new SampleFileData();
            sample.LabName = labName;

            var chemistry = new ChemistryFileData();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATChemistryParameters(mockDbContext, esdatModel, sample, chemistry);
            var mapper = new ChemistryOrganizationMapper(parameters);
            
            var organization = mapper.Scaffold();

            Assert.AreEqual(0, organization.OrganizationID);
            Assert.AreEqual("Laboratory", organization.OrganizationTypeCV);
            Assert.AreEqual(labName.Substring(0, 3), organization.OrganizationCode);
            Assert.AreEqual(labName, organization.OrganizationName);
            Assert.AreEqual(null, organization.OrganizationDescription);
            Assert.AreEqual(null, organization.OrganizationLink);
            Assert.AreEqual(null, organization.ParentOrganizationID);
        }
    }
}
