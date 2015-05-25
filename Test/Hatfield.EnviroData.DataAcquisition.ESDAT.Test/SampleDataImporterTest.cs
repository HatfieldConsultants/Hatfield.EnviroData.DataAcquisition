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
    public class SampleDataImporterTest
    {
        [Test]
        public void ExtractSampleDataFileTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var sampleDataFileImporter = ESDATTestHelper.BuildSampleDataFileImporter();

            var extractResult = sampleDataFileImporter.Extract<SampleFileData>(dataToImport);

            var allFailResults = extractResult.AllParsingResults.Where(x => x.Level == ResultLevel.ERROR).ToList();

            Assert.NotNull(extractResult);
            Assert.AreEqual(ResultLevel.ERROR, extractResult.ThresholdLevel);
            Assert.False(allFailResults.Any());
            Assert.AreEqual(true, extractResult.IsExtractedSuccess);
            Assert.AreEqual(3, extractResult.ExtractedEntities.Count());

            var firstEntity = extractResult.ExtractedEntities.FirstOrDefault();
            
            Assert.NotNull(firstEntity);
            Assert.AreEqual("5828314", firstEntity.SampleCode);
            Assert.AreEqual(new DateTime(2014, 9, 16), firstEntity.SampledDateTime);
            Assert.AreEqual("FRL-1 @ 16:00", firstEntity.FieldID);
            Assert.Null(firstEntity.SampleDepth);
            Assert.AreEqual("Water", firstEntity.MatrixType);
            Assert.AreEqual("Normal", firstEntity.SampleType);
            Assert.AreEqual(string.Empty, firstEntity.ParentSample);
            Assert.AreEqual("14J891101", firstEntity.SDG);
            Assert.AreEqual("AGAT", firstEntity.LabName);
            Assert.AreEqual("5828314", firstEntity.LabSampleID);
            Assert.AreEqual(string.Empty, firstEntity.Comments);
            Assert.AreEqual("14J891101", firstEntity.LabReportNumber);
        }


        
    }
}
