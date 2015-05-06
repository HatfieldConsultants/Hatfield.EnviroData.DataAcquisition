using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;
using Hatfield.EnviroData.DataAcquisition.CSV.Parsers;
using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class SimpleCSVDataImporterTest
    {
        [Test]
        public void ExtractDataTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");
            var dataSource = new LocalFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);
            
            var dataImporter = new TestImporterBuilder().Build();

            var extractedDataSet = dataImporter.Extract<TestDataModel>(dataToImport);

            Assert.NotNull(extractedDataSet);
            Assert.AreEqual(true, extractedDataSet.IsExtractedSuccess);
            Assert.AreEqual(8, extractedDataSet.ExtractedEntities.Count());

        }

        [Test]
        public void ExtractDataNotValidFormatTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CSV_15min.csv");
            var dataSource = new LocalFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var dataImporter = new TestImporterBuilder().Build();

            var extractedDataSet = dataImporter.Extract<TestDataModel>(dataToImport);

            Assert.NotNull(extractedDataSet);
            Assert.AreEqual(false, extractedDataSet.IsExtractedSuccess);
            Assert.Null(extractedDataSet.ExtractedEntities);

        }
    }

}
