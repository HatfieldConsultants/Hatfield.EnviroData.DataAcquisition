using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.ESDAT;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class ESDATDataModelTest
    {
        [Test]
        public void SampleFileDataConstructorTest()
        {
            var sampleFileData = new SampleFileData("test sample code",
                                                    new DateTime(2015, 5, 26),
                                                    "test field ID",
                                                    1.0,
                                                    "test matrix type",
                                                    "test sample type",
                                                    "test parent sample",
                                                    "sdg",
                                                    "test lab name",
                                                    "test lab sample ID",
                                                    "test comment",
                                                    "test lab report number");

            Assert.NotNull(sampleFileData);
            Assert.AreEqual("test sample code", sampleFileData.SampleCode);
            Assert.AreEqual(new DateTime(2015, 5, 26), sampleFileData.SampledDateTime);
            Assert.AreEqual("test field ID", sampleFileData.FieldID);
            Assert.AreEqual(1.0, sampleFileData.SampleDepth);
            Assert.AreEqual("test matrix type", sampleFileData.MatrixType);
            Assert.AreEqual("test sample type", sampleFileData.SampleType);
            Assert.AreEqual("test parent sample", sampleFileData.ParentSample);
            Assert.AreEqual("sdg", sampleFileData.SDG);
            Assert.AreEqual("test lab name", sampleFileData.LabName);
            Assert.AreEqual("test lab sample ID", sampleFileData.LabSampleID);
            Assert.AreEqual("test comment", sampleFileData.Comments);
            Assert.AreEqual("test lab report number", sampleFileData.LabReportNumber);
        }

        [Test]
        public void ChemistryFileDataConstructorTest()
        {
            var chemistryFileData = new ChemistryFileData("test sample code",
                                                         "test original chemistry name",
                                                         "test chem code",
                                                         "test prefix", 
                                                         1.1,
                                                         "test result unit",
                                                         "Total",
                                                         "test result type",
                                                         "test method type",
                                                         "test method name",
                                                         new DateTime(2014, 1, 2),
                                                         new DateTime(2014, 2, 3),
                                                         2.2,
                                                         "%",
                                                         "good data",
                                                         "Good",
                                                         3.3,
                                                         4.4);

            Assert.NotNull(chemistryFileData);
            Assert.AreEqual("test sample code", chemistryFileData.SampleCode);
            Assert.AreEqual("test original chemistry name", chemistryFileData.OriginalChemName);
            Assert.AreEqual("test chem code", chemistryFileData.ChemCode);
            Assert.AreEqual("test prefix", chemistryFileData.Prefix);
            Assert.AreEqual(1.1, chemistryFileData.Result);
            Assert.AreEqual("test result unit", chemistryFileData.ResultUnit);
            Assert.AreEqual("Total", chemistryFileData.TotalOrFiltered);
            Assert.AreEqual("test result type", chemistryFileData.ResultType);
            Assert.AreEqual("test method type", chemistryFileData.MethodType);
            Assert.AreEqual("test method name", chemistryFileData.MethodName);
            Assert.AreEqual(new DateTime(2014, 1, 2), chemistryFileData.ExtractionDate);
            Assert.AreEqual(new DateTime(2014, 2, 3), chemistryFileData.AnalysedDate);
            Assert.AreEqual(2.2, chemistryFileData.EQL);
            Assert.AreEqual("%", chemistryFileData.EQLUnits);
            Assert.AreEqual("good data", chemistryFileData.Comments);
            Assert.AreEqual("Good", chemistryFileData.LabQualifier);
            Assert.AreEqual(3.3, chemistryFileData.UCL);
            Assert.AreEqual(4.4, chemistryFileData.LCL);
        }
    }
}
