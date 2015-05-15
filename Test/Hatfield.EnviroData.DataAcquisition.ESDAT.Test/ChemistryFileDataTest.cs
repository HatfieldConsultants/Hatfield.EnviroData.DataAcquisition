using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Moq;

using Hatfield.EnviroData.DataAcquisition.ESDAT;

namespace Hatfield.EnviroData.DataAcquisition.Test
{
    [TestFixture]
    public class ChemistryFileDataTest
    {
        [Test]
        public void InstantiationTest()
        {
            string sampleCode = "a";
            string originalChemName = "b";
            string chemCode = "c";
            char prefix = 'd';
            double result = 1;
            string resultUnit = "e";
            bool totalOrUnfiltered = true;
            string resultType = "f";
            string methodType = "g";
            string methodName = "h";
            DateTime extractionDate = new DateTime(1);
            DateTime analysedDate = new DateTime(2);
            double eql = 3;
            string eqlUnits = "i";
            string comments = "j";
            string labQualifier = "k";
            double ucl = 4;
            double lcl = 5;

            ChemistryFileData chemistryFileData = new ChemistryFileData(sampleCode, originalChemName, chemCode, prefix, result, resultUnit, totalOrUnfiltered, resultType, methodType, methodName, extractionDate, analysedDate, eql, eqlUnits, comments, labQualifier, ucl, lcl);

            Assert.AreEqual(chemistryFileData.SampleCode, sampleCode);
            Assert.AreEqual(chemistryFileData.OriginalChemName, originalChemName);
            Assert.AreEqual(chemistryFileData.ChemCode, chemCode);
            Assert.AreEqual(chemistryFileData.Prefix, prefix);
            Assert.AreEqual(chemistryFileData.Result, result);
            Assert.AreEqual(chemistryFileData.ResultUnit, resultUnit);
            Assert.AreEqual(chemistryFileData.TotalOrUnfiltered, totalOrUnfiltered);
            Assert.AreEqual(chemistryFileData.ResultType, resultType);
            Assert.AreEqual(chemistryFileData.MethodType, methodType);
            Assert.AreEqual(chemistryFileData.MethodName, methodName);
            Assert.AreEqual(chemistryFileData.ExtractionDate, extractionDate);
            Assert.AreEqual(chemistryFileData.AnalysedDate, analysedDate);
            Assert.AreEqual(chemistryFileData.EQL, eql);
            Assert.AreEqual(chemistryFileData.EQLUnits, eqlUnits);
            Assert.AreEqual(chemistryFileData.Comments, comments);
            Assert.AreEqual(chemistryFileData.LabQualifier, labQualifier);
            Assert.AreEqual(chemistryFileData.UCL, ucl);
            Assert.AreEqual(chemistryFileData.LCL, lcl);
        }
    }
}
