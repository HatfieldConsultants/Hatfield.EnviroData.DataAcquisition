using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.CSV.Parsers;
using Hatfield.EnviroData.DataAcquisition.FileSystems;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.ESDAT;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class SimpleCSVDataImporterTest
    {
        [Test]
        public void ExtractDataTest()
        {
            var dataToImport = GetDataToImport("DAT_15min.dat");
            var dataImporter = new TestImporterBuilder().Build();
            var extractedDataSet = dataImporter.Extract<TestDataModel>(dataToImport);

            Assert.NotNull(extractedDataSet);
            Assert.AreEqual(true, extractedDataSet.IsExtractedSuccess);
            Assert.AreEqual(8, extractedDataSet.ExtractedEntities.Count());
            Assert.AreEqual(ResultLevel.ERROR, dataImporter.ThresholdLevel);

        }

        [Test]
        public void ExtractDataNotValidFormatTest()
        {
            var dataToImport = GetDataToImport("CSV_15min.csv");

            var dataImporter = new TestImporterBuilder().Build();

            var extractedDataSet = dataImporter.Extract<ESDATModel>(dataToImport);

            Assert.NotNull(extractedDataSet);

            Assert.AreEqual(false, extractedDataSet.IsExtractedSuccess);
            Assert.Null(extractedDataSet.ExtractedEntities);
            Assert.AreEqual(ResultLevel.ERROR, dataImporter.ThresholdLevel);

        }

        [Test]
        [TestCase("DAT_15min.dat", true)]
        [TestCase("CSV_15min.csv", false)]
        public void IsDataSupportedTest(string fileName, bool expectedIsSupported)
        {
            var dataToImport = GetDataToImport(fileName);
            var dataImporter = new TestImporterBuilder().Build();

            var actualIsDataSupported = dataImporter.IsDataSupported(dataToImport);

            Assert.AreEqual(expectedIsSupported, actualIsDataSupported);
        }

        [Test]
        public void AllValidationRulesGetterTest()
        {
            var dataToImport = GetDataToImport("DAT_15min.dat");
            var dataImporter = new TestImporterBuilder().Build();

            var validationRules = dataImporter.AllValidationRules;

            Assert.NotNull(validationRules);

            var firstRule = validationRules.ElementAt(0);
            Assert.IsInstanceOf<CSVFileNameExtensionMatchValidationRule>(firstRule);

            var secondRule = validationRules.ElementAt(1);
            Assert.IsInstanceOf<CellValueMatchCriteriaValidationRule>(secondRule);
        }

        [Test]
        public void ExtractConfigurationsGetterTest()
        {
            var dataToImport = GetDataToImport("DAT_15min.dat");
            var dataImporter = new TestImporterBuilder().Build();
            var configurations = dataImporter.ExtractConfigurations;

            var firstConfiguration = configurations.ElementAt(0);
            
            Assert.NotNull(configurations);
            Assert.AreEqual(3, configurations.Count());

            Assert.AreEqual("DateTime", firstConfiguration.PropertyPath);
            Assert.IsInstanceOf<CellParser>(firstConfiguration.PropertyParser);
            Assert.IsInstanceOf<SimpleValueAssigner>(firstConfiguration.PropertyValueAssigner);
        }

        private IDataToImport GetDataToImport(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", fileName);
            var dataSource = new LocalFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            return dataToImport;
        }
    }

}
