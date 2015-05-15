using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Moq;

using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.Test
{
    [TestFixture]
    public class ESDATDataConverterTest
    {
        // See https://github.com/HatfieldConsultants/Hatfield.EnviroData.Core/wiki/Loading-ESDAT-data-into-ODM2#actions for expected values
        [Test]
        public void ESDATDataConverterConvertToODMActionActionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var esdatConverter = new ESDATDataConverter(mockDbContext);
            ESDATModel esdatModel = new ESDATModel();
            DateTime sampledDateTime = DateTime.Now;
            esdatModel.SampleFileData.SampledDateTime = sampledDateTime;
            var action = esdatConverter.ConvertToODMAction(esdatModel);

            Assert.AreEqual(action.ActionID, 0);
            Assert.AreEqual(action.ActionTypeCV, "specimenCollection");
            Assert.AreEqual(action.BeginDateTime, sampledDateTime);
            Assert.AreEqual(action.EndDateTime, null);
            Assert.AreEqual(action.EndDateTimeUTCOffset, null);
            Assert.AreEqual(action.ActionDescription, null);
            Assert.AreEqual(action.ActionFileLink, null);
        }
    }
}
