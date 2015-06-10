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
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new FeatureActionMapper(mockDbContext, duplicateChecker);

            var esdatModel = new ESDATModel();
            var featureAction = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new FeatureActionMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            var featureAction = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, featureAction.FeatureActionID);
            Assert.AreEqual(0, featureAction.SamplingFeatureID);
            Assert.AreEqual(0, featureAction.ActionID);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new FeatureActionMapper(mockDbContext, duplicateChecker);

            var entity1 = new SamplingFeature();
            var entity2 = new SamplingFeature();
            var entity3 = new Result();
            var entity4 = new Result();
            var entity = new FeatureAction();
            entity = mapper.Link(entity, entity1, entity3);

            Assert.AreEqual(entity1, entity.SamplingFeature);
            Assert.AreNotEqual(entity2, entity.SamplingFeature);
            Assert.IsTrue(entity.Results.Contains(entity3));
            Assert.IsFalse(entity.Results.Contains(entity4));
        }
    }
}
