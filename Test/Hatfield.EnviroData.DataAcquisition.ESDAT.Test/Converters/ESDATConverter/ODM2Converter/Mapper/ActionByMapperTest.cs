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
    class ActionByMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ActionByMapper(mockDbContext, duplicateChecker);

            var action = new Core.Action();
            action.ActionID = 101;

            var actionBy = mapper.Scaffold(action);

            Assert.AreEqual(0, actionBy.BridgeID);
            Assert.AreEqual(action.ActionID, actionBy.ActionID);
            Assert.AreEqual(true, actionBy.IsActionLead);
            Assert.AreEqual(null, actionBy.RoleDescription);
            Assert.AreEqual(action, actionBy.Action);
        }

        [Test]
        public void LinkTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var mapper = new ActionByMapper(mockDbContext, duplicateChecker);

            var entity = new ActionBy();
            var affiliation = new Affiliation();
            
            entity = mapper.Link(entity, affiliation);

            Assert.AreEqual(affiliation, entity.Affiliation);
            Assert.AreEqual(affiliation.AffiliationID, entity.AffiliationID);
        }
    }
}
