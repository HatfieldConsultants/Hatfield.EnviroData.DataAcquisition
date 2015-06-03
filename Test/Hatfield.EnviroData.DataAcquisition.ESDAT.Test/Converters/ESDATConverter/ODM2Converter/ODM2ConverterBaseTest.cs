using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ODM2ConverterBaseTest
    {
        [Test]
        public void Test()
        {
            var mockDbContext = new Mock<IDbContext>().Object;
            var odm2ConverterBase = new ODM2ConverterBase(mockDbContext);

            Assert.AreEqual(mockDbContext, odm2ConverterBase.DbContext);
        }
    }
}
