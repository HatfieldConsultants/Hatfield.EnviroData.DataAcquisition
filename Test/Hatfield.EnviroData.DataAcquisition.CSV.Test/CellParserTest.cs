using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Moq;

using Hatfield.EnviroData.DataAcquisition.CSV.Parsers;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class CellParserTest
    {
        [Test]
        public void NotSupportDataSourceLocationTest()
        {
            var mockDataSourceLocation = new Mock<IDataSourceLocation>();
            var mockDataToImport = new Mock<IDataToImport>();

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new CellParser(parserFactory);

            var testParsingResult = testCellParser.Parse(mockDataToImport.Object, mockDataSourceLocation.Object, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            Assert.AreEqual("Castle.Proxies.IDataSourceLocationProxy is not supported by CSV Cell Parser", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void NotSupportDataSourceTest()
        {
            var dataSourceLocation = new CSVDataSourceLocation(0, 0);
            var mockDataToImport = new Mock<IDataToImport>();

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new CellParser(parserFactory);

            var testParsingResult = testCellParser.Parse(mockDataToImport.Object, dataSourceLocation, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            Assert.AreEqual("Castle.Proxies.IDataToImportProxy is not supported by CSV Cell Parser", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void OutOfRangeTest()
        {
            var dataSourceLocation = new CSVDataSourceLocation(5, 0);
            var dataToImport = new CSVDataToImport("test.csv",
                                                    new string[][]{
                                                        new string[]{"1", "2", "3"}
                                                    }
                                                  );

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new CellParser(parserFactory);

            var testParsingResult = testCellParser.Parse(dataToImport, dataSourceLocation, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            Assert.AreEqual("Index is out of range", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void PasingSuccessTest()
        {
            var dataSourceLocation = new CSVDataSourceLocation(0, 0);
            var dataToImport = new CSVDataToImport("test.csv",
                                                    new string[][]{
                                                        new string[]{"1", "2", "3"}
                                                    }
                                                  );

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new CellParser(parserFactory);

            var testParsingResult = testCellParser.Parse(dataToImport, dataSourceLocation, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.INFO, testParsingResult.Level);
            Assert.AreEqual("Parsing value successfully", testParsingResult.Message);
            Assert.AreEqual(1, (int)testParsingResult.Value);
        }
    }
}
