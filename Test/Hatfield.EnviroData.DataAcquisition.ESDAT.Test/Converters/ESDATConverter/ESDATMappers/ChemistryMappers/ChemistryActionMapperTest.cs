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
    class ChemistryActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var chemistry = new ChemistryFileData();
            chemistry.AnalysedDate = DateTime.Now;

            var esdatModel = new ESDATModel();
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var results = new List<IResult>();
            var factory = new ESDATChemistryMapperFactory(duplicateChecker, defaultValueProvider, wayToHandleNewData, results);
            var mapper = new ChemistryActionMapper(duplicateChecker, factory, defaultValueProvider, wayToHandleNewData, results);

            var action = mapper.Draft(esdatModel, chemistry);

            Assert.AreEqual(defaultValueProvider.ActionTypeCVChemistry, action.ActionTypeCV);
            Assert.AreEqual(chemistry.ExtractionDate, action.BeginDateTime);
            Assert.AreEqual(chemistry.AnalysedDate, action.EndDateTime);
        }
    }
}
