using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.FileSystems;
using Hatfield.EnviroData.DataAcquisition.CSV;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class CSVDataToImportTest
    {
        private string _csvDataFilePath;
        private string _datDataFilePath;

        [TestFixtureSetUp]
        public void Setup()
        {
            _csvDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CSV_15min.csv");
            _datDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");
        }

        [Test]
        public void CSVDataToImportReadCSVFileTest()
        {
            var dataSource = new LocalFileSystem(_csvDataFilePath);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);
            AssertData(Path.GetFileName(_csvDataFilePath), dataToImport);
        }

        [Test]
        public void CSVDataToImportReadDatFileTest()
        {            
            var dataSource = new LocalFileSystem(_datDataFilePath);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            AssertData(Path.GetFileName(_datDataFilePath), dataToImport);
        }
        

        private void AssertData(string fileName, CSVDataToImport csvDataToImport)
        {           

            Assert.AreEqual(fileName, csvDataToImport.FileName);
            Assert.NotNull(csvDataToImport);
            var castedData = csvDataToImport.Data as string[][];
            Assert.NotNull(castedData);
            Assert.AreEqual(12, castedData.Count());
            Assert.AreEqual("TOA5", castedData[0][0]);
        }
    }
}
