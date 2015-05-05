using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.CSV;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class CSVDataSourceTest
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
        public void CSVDataSourceReadCSVFileTest()
        {
            var dataSource = new CSVDataSource(_csvDataFilePath);

            AssertData(Path.GetFileName(_csvDataFilePath), dataSource);
        }

        [Test]
        public void CSVDataSourceReadDatFileTest()
        {
            var dataSource = new CSVDataSource(_datDataFilePath);

            AssertData(Path.GetFileName(_datDataFilePath), dataSource);
        }

        [Test]
        public void CSVDataSourceReadTextReaderTest()
        {
            var textReader = File.OpenText(_csvDataFilePath);
            var dataSource = new CSVDataSource("CSV_15min.csv", textReader);

            AssertData("CSV_15min.csv", dataSource);
        }

        [Test]
        public void CSVDataSourceReadStreamTest()
        {
            var dataStream = new FileStream(_csvDataFilePath, FileMode.Open);
            var dataSource = new CSVDataSource("DAT_15min.dat", dataStream);

            AssertData("DAT_15min.dat", dataSource);
        }

        private void AssertData(string fileName, CSVDataSource dataSource)
        {
            var csvData = dataSource.FetchData();

            Assert.AreEqual(fileName, ((CSVDataToImport)csvData).FileName);
            Assert.NotNull(csvData);
            var castedData = csvData.Data as string[][];
            Assert.NotNull(castedData);
            Assert.AreEqual(12, castedData.Count());
            Assert.AreEqual("TOA5", castedData[0][0]);
        }
    }
}
