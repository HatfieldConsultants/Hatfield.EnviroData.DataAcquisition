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
    class SampleCollectionOrganizationMapperTest
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
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var mapper = new SampleCollectionOrganizationMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            var organization = mapper.Draft(esdatModel);

            Assert.AreEqual(defaultValueProvider.OrganizationTypeCVSampleCollection, organization.OrganizationTypeCV);
            Assert.AreEqual(mapper.GetOrganizationCode(defaultValueProvider.OrganizationNameSampleCollection), organization.OrganizationCode);
            Assert.AreEqual(defaultValueProvider.OrganizationNameSampleCollection, organization.OrganizationName);
        }
    }
}
