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
    class SampleCollectionActionMapperTest
    {
        [Test]
        public void ScaffoldTest()
        {
            var esdatModel = new ESDATModel();
            esdatModel.DateReported = DateTime.Now;

            var mockDb = new Mock<IDbContext>();
            var mockDbContext = mockDb.Object;
            var parameters = new ESDATSampleCollectionParameters(mockDbContext, esdatModel);
            var factory = new ESDATSampleCollectionMapperSingletonFactory(parameters);
            var mapper = new SampleCollectionActionMapper(factory, parameters);

            var action = mapper.Scaffold();

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("Specimen collection", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(esdatModel.DateReported, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }
    }
}
