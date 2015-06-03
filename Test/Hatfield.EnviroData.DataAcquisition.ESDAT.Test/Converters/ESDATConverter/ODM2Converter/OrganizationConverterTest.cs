using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class OrganizationConverterTest
    {
        [Test]
        public void OrganizationTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.LabName = "XYZ Corp";
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var organizationConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Organization)) as OrganizationConverter;
            var organization = organizationConverter.Convert(esdatModel, converterFactory);

            Assert.AreEqual(0, organization.OrganizationID);
            Assert.AreEqual("Company", organization.OrganizationTypeCV);
            Assert.AreEqual(esdatModel.LabName.Substring(0, 3), organization.OrganizationCode);
            Assert.AreEqual(esdatModel.LabName, organization.OrganizationName);
            Assert.AreEqual(null, organization.OrganizationDescription);
            Assert.AreEqual(null, organization.OrganizationLink);
            Assert.AreEqual(null, organization.ParentOrganizationID);
        }
    }
}
