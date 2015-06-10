using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.JSON;

namespace Hatfield.EnviroData.DataAcquisition.JSON.Test
{
    [TestFixture]
    public class JSONDataSourceLocationTest
    {
        [Test]
        public void LocationTest()
        {
            var testLocation = new JSONDataSourceLocation("test path", true);

            Assert.NotNull(testLocation);
            Assert.AreEqual("test path", testLocation.Path);
            Assert.AreEqual(true, testLocation.IsArray);
        }
    }
}
