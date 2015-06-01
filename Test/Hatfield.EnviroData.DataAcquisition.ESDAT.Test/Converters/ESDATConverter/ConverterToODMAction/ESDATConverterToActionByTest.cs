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
    class ESDATConverterToActionByTest : ESDATConverterToODMActionTest
    {
        [Test]
        public void ActionByTest()
        {
            var action = new Core.Action();
            action.ActionID = 101;

            var actionBy = actionByConverter.Convert(action, affiliationConverter, personConverter);
            var affiliation = actionBy.Affiliation;

            Assert.AreEqual(0, actionBy.BridgeID);
            Assert.AreEqual(action.ActionID, actionBy.ActionID);
            Assert.AreEqual(affiliation.AffiliationID, actionBy.AffiliationID);
            Assert.AreEqual(true, actionBy.IsActionLead);
            Assert.AreEqual(null, actionBy.RoleDescription);
            Assert.AreEqual(action, actionBy.Action);
            Assert.AreEqual(affiliation, actionBy.Affiliation);
        }
    }
}
