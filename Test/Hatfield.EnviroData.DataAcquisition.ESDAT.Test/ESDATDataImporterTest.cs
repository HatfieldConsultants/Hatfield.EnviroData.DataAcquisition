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
using Hatfield.EnviroData.DataAcquisition.ESDAT.Importer;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class ESDATDataImporterTest
    {
        [Test]
        public void ExtractESDATDataTest()
        {
            var chemistryFileToImport = CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv"));
            var sampleFileToImport = CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv"));

            var testESDATDataToImport = new ESDATDataToImport(null, sampleFileToImport, chemistryFileToImport);

            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();
            var sampleFileChildObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            var chemistryDataImporter = ESDATTestHelper.BuildChemistryFileImporter();
            var chemistryFileChildObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryDataImporter, "ChemistryData", simpleValueAssginer);

            var testESDATDataImporter = new ESDATDataImporter(ResultLevel.ERROR);
            testESDATDataImporter.AddExtractConfiguration(sampleFileChildObjectExtractConfiguration);
            testESDATDataImporter.AddExtractConfiguration(chemistryFileChildObjectExtractConfiguration);

            var extractResult = testESDATDataImporter.Extract<ESDATModel>(testESDATDataToImport);

            Assert.NotNull(extractResult);

            var entity = extractResult.ExtractedEntities.Cast<ESDATModel>().SingleOrDefault();

            Assert.NotNull(entity);
            Assert.AreEqual(3, entity.SampleFileData.Count());
            Assert.AreEqual(9, entity.ChemistryData.Count());
        }

        private CSVDataToImport CreateCSVDataToImport(string filePath)
        {            
            var dataSource = new WindowsFileSystem(filePath);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            return dataToImport;        
        }        

        private IExtractConfiguration CreateChemistryFileDataExtractConfiguration()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var chemistryImporter = ESDATTestHelper.BuildChemistryFileImporter();

            var childObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryImporter, "ChemistryData", simpleValueAssginer);

            return childObjectExtractConfiguration;
        }

        private IExtractConfiguration CreateSampleFileDataExtractConfiguration()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();

            var childObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            return childObjectExtractConfiguration;
        }
    }
}
