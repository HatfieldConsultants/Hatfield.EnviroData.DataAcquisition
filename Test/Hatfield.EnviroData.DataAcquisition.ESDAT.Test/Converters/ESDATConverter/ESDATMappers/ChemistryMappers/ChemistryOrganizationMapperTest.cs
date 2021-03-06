﻿using System;
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
    class ChemistryOrganizationMapperTest
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
            var mapper = new ChemistryOrganizationMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);

            mapper.SampleFileData = sample;

            var organization = mapper.Draft(esdatModel, chemistry);

            Assert.AreEqual(defaultValueProvider.OrganizationTypeCVChemistry, organization.OrganizationTypeCV);
            Assert.AreEqual(sample.LabName.Substring(0, 3), organization.OrganizationCode);
            Assert.AreEqual(sample.LabName, organization.OrganizationName);
        }
    }
}
