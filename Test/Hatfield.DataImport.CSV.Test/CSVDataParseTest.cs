using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;
using Hatfield.EnviroData.DataImport.CSV.Parsers;

namespace Hatfield.EnviroData.DataImport.CSV.Test
{
    [TestFixture]
    public class CSVDataParseTest
    {
        private string _csvDataFilePath;
        private string _datDataFilePath;
        private string[][] _rows;
        IDataSourceLocation dataSourceLocation;
        IDataToImport dataToImport;


        [TestFixtureSetUp]
        public void Setup()
        {
            _csvDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CSV_15min.csv");
            _datDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");           
        }


        [Test]
        public void CSVParseTestSuccess()
        {
            var dataSource = new CSVDataSource(_csvDataFilePath);
            var dataSourceLocation = new CSVDataSourceLocation(6, 3);
            var dataDateTimeSourceLocation = new CSVDataSourceLocation(6, 0);

            dataToImport = dataSource.FetchData();
            var parser = new CellParser(new DefaultParserFactory());

            var parseDoubleResult = parser.Parse<double>(dataToImport, dataSourceLocation);

            Assert.NotNull(parseDoubleResult);
            Assert.AreEqual(parseDoubleResult.Level, ResultLevel.INFO);
            Assert.AreEqual(parseDoubleResult.Message, "Parsing value successfully");
            Assert.AreEqual(0.3, ((IParsingResult)parseDoubleResult).Value);

            var parseDateTimeResult = parser.Parse<DateTime>(dataToImport, dataDateTimeSourceLocation);

            Assert.NotNull(parseDateTimeResult);
            Assert.AreEqual(parseDateTimeResult.Level, ResultLevel.INFO);
            Assert.AreEqual(parseDateTimeResult.Message, "Parsing value successfully");
            Assert.AreEqual(new DateTime(2013, 12, 12, 14, 0, 0), ((IParsingResult)parseDateTimeResult).Value);
        }

    }
}
