using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ConverterToODMAction
{
    [TestFixture]
    class ESDATConverterToRelatedActionTest : ESDATConverterToODMActionTest
    {
        [Test]
        public void RelatedActionTest()
        {
            var parentAction = new Core.Action();
            parentAction.ActionID = 101;

            var childAction = new Core.Action();
            childAction.ActionID = 101;

            var relatedAction = relatedActionConverter.Convert(parentAction, childAction, "relationshipTypeCV");

            Assert.AreEqual(0, relatedAction.RelationID);
            Assert.AreEqual(parentAction.ActionID, relatedAction.ActionID);
            Assert.AreEqual("relationshipTypeCV", relatedAction.RelationshipTypeCV);
            Assert.AreEqual(childAction.ActionID, relatedAction.RelatedActionID);
            Assert.AreEqual(parentAction, relatedAction.Action);
            Assert.AreEqual(childAction, relatedAction.Action1);
        }
    }
}
