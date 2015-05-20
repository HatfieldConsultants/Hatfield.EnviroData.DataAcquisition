using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    public class ESDATConverterTest
    {
        // See https://github.com/HatfieldConsultants/Hatfield.EnviroData.Core/wiki/Loading-ESDAT-data-into-ODM2#actions for expected values
        [Test]
        public void ESDATConverterConvertToODMActionActionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var esdatConverter = new ESDATConverter(mockDbContext);
            ESDATModel esdatModel = new ESDATModel();
            var action = esdatConverter.ConvertToODMAction(esdatModel);

            Assert.AreEqual(action.ActionID, 0);
            Assert.AreEqual(action.ActionTypeCV, "specimenCollection");
            Assert.AreEqual(action.EndDateTime, null);
            Assert.AreEqual(action.EndDateTimeUTCOffset, null);
            Assert.AreEqual(action.ActionDescription, null);
            Assert.AreEqual(action.ActionFileLink, null);
        }
    }
}
