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
    class MethodConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var esdatModel = new ESDATModel();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var methodConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Method)) as MethodConverter;
            var method = methodConverter.Convert(esdatModel, converterFactory);

            Assert.AreEqual(0, method.MethodID);
            Assert.AreEqual("fieldActivity", method.MethodTypeCV);
            Assert.AreEqual(string.Empty, method.MethodCode);
            Assert.AreEqual("Sample Collection", method.MethodName);
            Assert.AreEqual(null, method.MethodDescription);
            Assert.AreEqual(null, method.MethodLink);
            Assert.AreEqual(null, method.OrganizationID);
        }
    }
}
