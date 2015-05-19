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

            return testImporter;
        
        }
    }
}

