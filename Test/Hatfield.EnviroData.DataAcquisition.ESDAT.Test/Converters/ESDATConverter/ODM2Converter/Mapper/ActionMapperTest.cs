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
    class ActionMapperTest
    {
        [Test]
        public void ScaffoldSampleCollectionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ActionMapper(mockDbContext, duplicateChecker);

            var esdatModel = new ESDATModel();
            esdatModel.DateReported = DateTime.Now;

            var action = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("specimenCollection", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(esdatModel.DateReported, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }

        [Test]
        public void ScaffoldChemistryTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ActionMapper(mockDbContext, duplicateChecker);

            var chemistry = new ChemistryFileData();
            chemistry.AnalysedDate = DateTime.Now;

            var action = mapper.Scaffold(chemistry);

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("specimenAnalysis", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(chemistry.AnalysedDate, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ActionMapper(mockDbContext, duplicateChecker);

            var featureActions = new List<FeatureAction>();
            var featureAction1 = new FeatureAction();
            featureActions.Add(featureAction1);
            var featureAction2 = new FeatureAction();

            var actionBies = new List<ActionBy>();
            var actionBy1 = new ActionBy();
            actionBies.Add(actionBy1);
            var actionBy2 = new ActionBy();

            var relatedActions = new List<RelatedAction>();
            var relatedAction1 = new RelatedAction();
            relatedActions.Add(relatedAction1);
            var relatedAction = new RelatedAction();

            var method1 = new Method();
            var method2 = new Method();

            var entity = new Core.Action();
            entity = mapper.Link(entity, featureActions, actionBies, relatedActions, method1);

            Assert.IsTrue(entity.FeatureActions.Contains(featureAction1));
            Assert.IsFalse(entity.FeatureActions.Contains(featureAction2));

            Assert.IsTrue(entity.ActionBies.Contains(actionBy1));
            Assert.IsFalse(entity.ActionBies.Contains(actionBy2));

            Assert.IsTrue(entity.RelatedActions.Contains(relatedAction1));
            Assert.IsFalse(entity.RelatedActions.Contains(relatedAction));

            Assert.AreEqual(method1, entity.Method);
            Assert.AreEqual(method1.MethodID, entity.Method.MethodID);
        }
    }
}
