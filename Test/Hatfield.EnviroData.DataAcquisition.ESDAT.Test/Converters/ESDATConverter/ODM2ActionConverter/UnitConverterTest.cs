using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ODMActionConverter
{
    [TestFixture]
    class UnitConverterTest : ODM2ActionConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var sample = new SampleFileData();
            var result = new Result();
            var unit = unitConverter.Convert(result, sample);

            Assert.AreEqual(0, unit.UnitsID, 0);
            Assert.AreEqual(string.Empty, unit.UnitsTypeCV);
            Assert.AreEqual(string.Empty, unit.UnitsAbbreviation);
            Assert.AreEqual(string.Empty, unit.UnitsName);
            Assert.IsTrue(unit.Results.Contains(result));
        }

        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            var result = new Result();
            chemistry.ResultUnit = "TestUnit";

            var unit = unitConverter.Convert(result, chemistry);

            Assert.AreEqual(0, unit.UnitsID, 0);
            Assert.AreEqual("TestUnit", unit.UnitsTypeCV);
            Assert.AreEqual("Te", unit.UnitsAbbreviation);
            Assert.AreEqual("TestUnit", unit.UnitsName);
            Assert.IsTrue(unit.Results.Contains(result));
        }
    }
}
