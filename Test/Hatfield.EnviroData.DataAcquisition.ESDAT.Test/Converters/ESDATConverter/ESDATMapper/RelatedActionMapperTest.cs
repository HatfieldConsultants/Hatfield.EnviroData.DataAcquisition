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
    class RelatedActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new RelatedActionMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var action1 = new Core.Action();
            action1.ActionID = 101;

            var action2 = new Core.Action();
            action2.ActionID = 102;
            var relatedAction = mapper.Scaffold(action1, "relationshipTypeCV", action2);

            Assert.AreEqual(0, relatedAction.RelationID);
            Assert.AreEqual(action1.ActionID, relatedAction.ActionID);
            Assert.AreEqual("relationshipTypeCV", relatedAction.RelationshipTypeCV);
            Assert.AreEqual(action2.ActionID, relatedAction.RelatedActionID);
            Assert.AreEqual(action1, relatedAction.Action);
            Assert.AreEqual(action2, relatedAction.Action1);
        }

        [Test]
        public void CheckDuplicateTest()
        {
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new RelatedActionMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var sampleRelatedAction = new RelatedAction();
            sampleRelatedAction.RelatedActionID = 101;

            var resultList = new List<RelatedAction>() { sampleRelatedAction }.AsQueryable();
            mockDb.Setup(x => x.Query<RelatedAction>()).Returns(resultList);

            var result = mapper.GetDuplicate(sampleRelatedAction);

            Assert.AreEqual(sampleRelatedAction.RelatedActionID, sampleRelatedAction.RelatedActionID);
        }
    }
}
