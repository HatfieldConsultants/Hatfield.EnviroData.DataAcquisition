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
            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new ODM2DuplicateChecker(mockDbContext);
            var esdatLinker = new ESDATLinker();
            var factory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker, esdatLinker);
            var mapper = new ActionByMapper(mockDbContext, factory, duplicateChecker, esdatLinker);

            var action = new Core.Action();
            action.ActionID = 101;

            var actionBy = mapper.Scaffold();

            Assert.AreEqual(0, actionBy.BridgeID);
            Assert.AreEqual(true, actionBy.IsActionLead);
            Assert.AreEqual(null, actionBy.RoleDescription);
        }
    }
}
