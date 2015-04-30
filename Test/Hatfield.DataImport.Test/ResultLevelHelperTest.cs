using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport;

namespace Hatfield.EnviroData.DataImport.Test
{
    [TestFixture]
    public class ResultLevelHelperTest
    {
        [Test]
        [TestCase(ResultLevel.DEBUG, ResultLevel.DEBUG, true)]
        [TestCase(ResultLevel.DEBUG, ResultLevel.INFO, true)]
        [TestCase(ResultLevel.DEBUG, ResultLevel.WARN, true)]
        [TestCase(ResultLevel.DEBUG, ResultLevel.ERROR, true)]
        [TestCase(ResultLevel.DEBUG, ResultLevel.FATAL, true)]
        [TestCase(ResultLevel.INFO, ResultLevel.DEBUG, false)]
        [TestCase(ResultLevel.INFO, ResultLevel.INFO, true)]
        [TestCase(ResultLevel.INFO, ResultLevel.WARN, true)]
        [TestCase(ResultLevel.INFO, ResultLevel.ERROR, true)]
        [TestCase(ResultLevel.INFO, ResultLevel.FATAL, true)]
        [TestCase(ResultLevel.WARN, ResultLevel.DEBUG, false)]
        [TestCase(ResultLevel.WARN, ResultLevel.INFO, false)]
        [TestCase(ResultLevel.WARN, ResultLevel.WARN, true)]
        [TestCase(ResultLevel.WARN, ResultLevel.ERROR, true)]
        [TestCase(ResultLevel.WARN, ResultLevel.FATAL, true)]
        [TestCase(ResultLevel.ERROR, ResultLevel.DEBUG, false)]
        [TestCase(ResultLevel.ERROR, ResultLevel.INFO, false)]
        [TestCase(ResultLevel.ERROR, ResultLevel.WARN, false)]
        [TestCase(ResultLevel.ERROR, ResultLevel.ERROR, true)]
        [TestCase(ResultLevel.ERROR, ResultLevel.FATAL, true)]
        [TestCase(ResultLevel.FATAL, ResultLevel.DEBUG, false)]
        [TestCase(ResultLevel.FATAL, ResultLevel.INFO, false)]
        [TestCase(ResultLevel.FATAL, ResultLevel.WARN, false)]
        [TestCase(ResultLevel.FATAL, ResultLevel.ERROR, false)]
        [TestCase(ResultLevel.FATAL, ResultLevel.FATAL, true)]
        public void LevelIsHigherThanOrEqualToThresholdTest(ResultLevel threshold, ResultLevel actualLevel, bool isHigher)
        {
            var actualIsHigher = ResultLevelHelper.LevelIsHigherThanOrEqualToThreshold(threshold, actualLevel);

            Assert.AreEqual(isHigher, actualIsHigher);
        }
    }
}
