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
        
        [Test]
        public void ESDATConverterConvertToODMActionActionTest()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var esdatConverter = new ESDATConverter(mockDbContext);
            var esdatModel = new ESDATModel();
            var action = esdatConverter.ConvertToODMAction(esdatModel);
            
            // See https://goo.gl/ckWn22 for expected values
            Assert.AreEqual(action.ActionID, 0);
            Assert.AreEqual(action.EndDateTime, null);
            Assert.AreEqual(action.EndDateTimeUTCOffset, null);
            Assert.AreEqual(action.ActionDescription, null);
            Assert.AreEqual(action.ActionFileLink, null);

            Console.WriteLine(mockDbContext);
        }
    }
}
