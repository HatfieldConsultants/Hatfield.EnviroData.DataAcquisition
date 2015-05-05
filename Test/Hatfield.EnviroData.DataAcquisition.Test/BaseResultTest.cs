using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Hatfield.EnviroData.DataAcquisition.Test
{
    [TestFixture]
    public class BaseResultTest
    {
        [Test]
        public void ResultTest()
        {
            var result = new BaseResult(ResultLevel.ERROR, "test base result");

            Assert.NotNull(result);
            Assert.AreEqual(ResultLevel.ERROR, result.Level);
            Assert.AreEqual("test base result", result.Message);
        }
    }
}
