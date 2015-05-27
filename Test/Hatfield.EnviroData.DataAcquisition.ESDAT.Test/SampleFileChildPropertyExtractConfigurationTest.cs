using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.CSV;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class SampleFileChildPropertyExtractConfigurationTest
    {
        [Test]
        public void ChemistryFilePropertyTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();

            var childObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            Assert.AreEqual(typeof(SampleFileData), childObjectExtractConfiguration.ChildObjectType);

            var testESDATModel = new ESDATModel();

            var extractResult = childObjectExtractConfiguration.ExtractData(testESDATModel, dataToImport);

            Assert.NotNull(extractResult);
            Assert.AreEqual(3, testESDATModel.SampleFileData.Count());

            var firstSampleData = testESDATModel.SampleFileData.FirstOrDefault();

            Assert.NotNull(firstSampleData);
            Assert.AreEqual("5828314", firstSampleData.SampleCode);
            Assert.AreEqual(new DateTime(2014, 9, 16), firstSampleData.SampledDateTime);
            Assert.AreEqual("FRL-1 @ 16:00", firstSampleData.FieldID);
            Assert.Null(firstSampleData.SampleDepth);
            Assert.AreEqual("Water", firstSampleData.MatrixType);
            Assert.AreEqual("Normal", firstSampleData.SampleType);
            Assert.AreEqual(string.Empty, firstSampleData.ParentSample);
            Assert.AreEqual("14J891101", firstSampleData.SDG);
            Assert.AreEqual("AGAT", firstSampleData.LabName);
            Assert.AreEqual("5828314", firstSampleData.LabSampleID);
            Assert.AreEqual(string.Empty, firstSampleData.Comments);
            Assert.AreEqual("14J891101", firstSampleData.LabReportNumber);
        }
    }
}
