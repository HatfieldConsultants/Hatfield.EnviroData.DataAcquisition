using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataImport.CSV;

namespace Hatfield.EnviroData.DataImport.CSV.Test
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

            AssertData(dataSource);
        }

        [Test]
        public void CSVDataSourceReadDatFileTest()
        {
            var dataSource = new CSVDataSource(_datDataFilePath);

            AssertData(dataSource);
        }

        [Test]
        public void CSVDataSourceReadTextReaderTest()
        {
            var textReader = File.OpenText(_csvDataFilePath);
            var dataSource = new CSVDataSource(textReader);

            AssertData(dataSource);
        }

        [Test]
        public void CSVDataSourceReadStreamTest()
        {
            var dataStream = new FileStream(_csvDataFilePath, FileMode.Open);
            var dataSource = new CSVDataSource(dataStream);

            AssertData(dataSource);
        }

        private void AssertData(CSVDataSource dataSource)
        {
            var csvData = dataSource.FetchData();

            Assert.NotNull(csvData);
            var castedData = csvData.Data as string[][];
            Assert.NotNull(castedData);
            Assert.AreEqual(11033, castedData.Count());
            Assert.AreEqual("TOA5", castedData[0][0]);
        }
    }
}
