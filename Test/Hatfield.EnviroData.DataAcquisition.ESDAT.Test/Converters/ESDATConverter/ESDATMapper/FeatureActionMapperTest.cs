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
    class FeatureActionMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new FeatureActionMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var esdatModel = new ESDATModel();
            var featureAction = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new FeatureActionMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var chemistry = new ChemistryFileData();
            var featureAction = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }
    }
}
