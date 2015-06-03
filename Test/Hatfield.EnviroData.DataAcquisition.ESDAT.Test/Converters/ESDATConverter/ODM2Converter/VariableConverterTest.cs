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
    class VariableConverterTest
    {
        [Test]
        public void SampleCollectionTest()
        {
            var sample = new SampleFileData();
            var result = new Result();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var variableConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableConverter;
            var variable = variableConverter.Convert(sample, result);

            Assert.AreEqual(0, variable.VariableID);
            Assert.AreEqual("Sample", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(string.Empty, variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
            Assert.IsTrue(variable.Results.Contains(result));
        }

        [Test]
        public void ChemistryTest(){
            var chemistry = new ChemistryFileData();
            var result = new Result();
            chemistry.OriginalChemName = "TestOriginalChemName";
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var variableConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableConverter;
            var variable = variableConverter.Convert(chemistry, result);

            Assert.AreEqual(0, variable.VariableID);
            Assert.AreEqual("Chemistry", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual("TestOriginalChemName", variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
            Assert.IsTrue(variable.Results.Contains(result));
        }
    }
}
