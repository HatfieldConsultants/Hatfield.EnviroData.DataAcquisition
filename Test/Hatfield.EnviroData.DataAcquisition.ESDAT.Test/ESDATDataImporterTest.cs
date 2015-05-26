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
using Hatfield.EnviroData.DataAcquisition.XML;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class ESDATDataImporterTest
    {
        [Test]
        public void ExtractESDATDataTest()
        {
            var headerFileToImport = CreateXMLDatoToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml"));
            var chemistryFileToImport = CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv"));
            var sampleFileToImport = CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv"));

            var testESDATDataToImport = new ESDATDataToImport(headerFileToImport, sampleFileToImport, chemistryFileToImport);

            
            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();
            var sampleFileChildObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            var chemistryDataImporter = ESDATTestHelper.BuildChemistryFileImporter();
            var chemistryFileChildObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryDataImporter, "ChemistryData", simpleValueAssginer);

            var testESDATDataImporter = new ESDATDataImporter(ResultLevel.ERROR);

            AddXMLExtractConfigurationsToImporter(testESDATDataImporter);
            testESDATDataImporter.AddExtractConfiguration(sampleFileChildObjectExtractConfiguration);
            testESDATDataImporter.AddExtractConfiguration(chemistryFileChildObjectExtractConfiguration);

            var extractResult = testESDATDataImporter.Extract<ESDATModel>(testESDATDataToImport);

            Assert.NotNull(extractResult);

            var entity = extractResult.ExtractedEntities.Cast<ESDATModel>().SingleOrDefault();

            Assert.NotNull(entity);
            Assert.AreEqual("Lab1", entity.LabName);
            Assert.AreEqual(3, entity.SampleFileData.Count());
            Assert.AreEqual(9, entity.ChemistryData.Count());
        }

        private void AddXMLExtractConfigurationsToImporter(IDataImporter dataImporter)
        {
            var parserFactory = new DefaultXMLParserFactory();
            var labNameFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Name", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabName");

            var dateReportedFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Date_Reported", parserFactory.GetElementParser(typeof(DateTime)), new SimpleValueAssigner(), typeof(DateTime), "DateReported");

            var projectIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Project_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "ProjectId");

            var sdgIDFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "SDG_ID", parserFactory.GetElementParser(typeof(int)), new SimpleValueAssigner(), typeof(int), "SDGID");

            var labSignatoryFieldExtractConfiguration = new SimpleXMLExtractConfiguration("", "Lab_Signatory", parserFactory.GetElementParser(typeof(string)), new SimpleValueAssigner(), typeof(string), "LabSignatory");

            dataImporter.AddExtractConfiguration(labNameFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(dateReportedFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(projectIDFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(sdgIDFieldExtractConfiguration);
            dataImporter.AddExtractConfiguration(labSignatoryFieldExtractConfiguration);
        }

        private XMLDataToImport CreateXMLDatoToImport(string filePath)
        {
            var dataSource = new WindowsFileSystem(filePath);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new XMLDataToImport(dataFromFileSystem);

            return dataToImport;
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
