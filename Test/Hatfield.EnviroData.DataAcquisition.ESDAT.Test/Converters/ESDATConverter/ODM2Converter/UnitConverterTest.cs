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
    class UnitConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var sample = new SampleFileData();
            var result = new Result();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var unitConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitConverter;
            var unit = unitConverter.Convert(sample, result);

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
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var unitConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitConverter;
            var unit = unitConverter.Convert(chemistry, result);

            Assert.AreEqual(0, unit.UnitsID, 0);
            Assert.AreEqual("TestUnit", unit.UnitsTypeCV);
            Assert.AreEqual("Te", unit.UnitsAbbreviation);
            Assert.AreEqual("TestUnit", unit.UnitsName);
            Assert.IsTrue(unit.Results.Contains(result));
        }
    }
}
