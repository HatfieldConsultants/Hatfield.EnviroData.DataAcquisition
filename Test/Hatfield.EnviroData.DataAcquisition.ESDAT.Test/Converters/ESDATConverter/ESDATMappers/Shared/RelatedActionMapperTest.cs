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
    class RelatedActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ESDATDuplicateChecker(mockDbContext);
            var defaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;
            var mapper = new RelatedActionMapper(duplicateChecker, defaultValueProvider, wayToHandleNewData);

            var action1 = new Core.Action();
            action1.ActionID = 101;

            var action2 = new Core.Action();
            action2.ActionID = 102;

            mapper.SetRelationship(action1, "relationshipTypeCV", action2);

            var relatedAction = mapper.Scaffold(esdatModel);

            Assert.AreEqual(0, relatedAction.RelationID);
            Assert.AreEqual(action1.ActionID, relatedAction.ActionID);
            Assert.AreEqual("relationshipTypeCV", relatedAction.RelationshipTypeCV);
            Assert.AreEqual(action2.ActionID, relatedAction.RelatedActionID);
            Assert.AreEqual(action1, relatedAction.Action);
            Assert.AreEqual(action2, relatedAction.Action1);
        }
    }
}
