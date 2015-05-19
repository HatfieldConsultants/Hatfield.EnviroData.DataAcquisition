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
    public class ChemistryFileTestImporterTest
    {
        [Test]
        public void ExtractChemistryFileDataTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var chemistryFileImporter = BuildChemistryFileImporter();

            var extractResult = chemistryFileImporter.Extract<ChemistryFileData>(dataToImport);

            var allFailResults = extractResult.AllParsingResults.Where(x => x.Level == ResultLevel.ERROR).ToList();

            Assert.NotNull(extractResult);
            Assert.AreEqual(ResultLevel.ERROR, extractResult.ThresholdLevel);
            Assert.AreEqual(true, extractResult.IsExtractedSuccess);
            Assert.AreEqual(9, extractResult.ExtractedEntities.Count());

            var firstEntity = extractResult.ExtractedEntities.FirstOrDefault();

            Assert.NotNull(firstEntity);
            Assert.AreEqual("5828314", firstEntity.SampleCode);
            Assert.AreEqual("100-41-4", firstEntity.ChemCode);
            Assert.AreEqual("Ethylbenzene", firstEntity.OriginalChemName);
            Assert.AreEqual("<", firstEntity.Prefix);
            Assert.AreEqual(0.0005, firstEntity.Result);
            Assert.AreEqual("mg/L", firstEntity.ResultUnit);
            Assert.AreEqual("T", firstEntity.TotalOrFiltered);
            Assert.AreEqual("REG", firstEntity.ResultType);
            Assert.AreEqual("Inorganic", firstEntity.MethodType);
            Assert.AreEqual("TO 0332", firstEntity.MethodName);
            Assert.AreEqual(new DateTime(2014, 9, 23), firstEntity.ExtractionDate);
            Assert.AreEqual(new DateTime(2014, 9, 24), firstEntity.AnalysedDate);
            Assert.AreEqual(0.0005, firstEntity.EQL);
            Assert.AreEqual("mg/L", firstEntity.EQLUnits);
            Assert.AreEqual(string.Empty, firstEntity.Comments);
            Assert.AreEqual(50.0d, firstEntity.UCL);
            Assert.AreEqual(null, firstEntity.LCL);
        }

        private IDataImporter BuildChemistryFileImporter()
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
                                                                                    "ChemCode",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(2,
                                                                                    "OriginalChemName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(3,
                                                                                    "Prefix",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(4,
                                                                                    "Result",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(5,
                                                                                    "ResultUnit",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(6,
                                                                                    "TotalOrFiltered",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(7,
                                                                                    "ResultType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(8,
                                                                                    "MethodType",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(9,
                                                                                    "MethodName",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(10,
                                                                                    "ExtractionDate",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(11,
                                                                                    "AnalysedDate",
                                                                                    parserFactory.GetCellParser(typeof(DateTime?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(DateTime?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(12,
                                                                                    "EQL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(13,
                                                                                    "EQLUnits",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(14,
                                                                                    "Comments",
                                                                                    parserFactory.GetCellParser(typeof(string)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(string)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(16,
                                                                                    "UCL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));

            testImporter.AddExtractConfiguration(new SimpleCSVExtractConfiguration(17,
                                                                                    "LCL",
                                                                                    parserFactory.GetCellParser(typeof(double?)),
                                                                                    simpleValueAssigner,
                                                                                    typeof(double?)));
            return testImporter;
        
        }
    }
}

