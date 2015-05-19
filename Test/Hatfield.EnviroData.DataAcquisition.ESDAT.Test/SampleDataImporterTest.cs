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

            var sampleDataFileImporter = BuildSampleDataFileImporter();

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


        private IDataImporter BuildSampleDataFileImporter()
        {
            var simpleValueAssigner = new SimpleValueAssigner();

            var parserFactory = new DefaultCSVParserFactory();

            var testImporter = new SimpleCSVDataImporter(ResultLevel.ERROR, 1);

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(0,
                                                                                    "SampleCode",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(1,
                                                                                    "SampledDateTime",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(2,
                                                                                    "FieldID",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(4,
                                                                                    "SampleDepth",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(6,
                                                                                    "MatrixType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(7,
                                                                                    "SampleType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(8,
                                                                                    "ParentSample",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(10,
                                                                                    "SDG",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(11,
                                                                                    "LabName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(12,
                                                                                    "LabSampleID",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(13,
                                                                                    "Comments",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(14,
                                                                                    "LabReportNumber",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));
            return testImporter;
        }
    }
}
