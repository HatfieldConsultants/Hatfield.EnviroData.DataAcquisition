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
    class DatasetsResultMapperTest
    {
        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new DatasetsResultMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var chemistry = new ChemistryFileData();
            var DatasetsResult = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, DatasetsResult.BridgeID);
            Assert.AreEqual(0, DatasetsResult.DatasetID);
            Assert.AreEqual(0, DatasetsResult.ResultID);
        }
    }
}
