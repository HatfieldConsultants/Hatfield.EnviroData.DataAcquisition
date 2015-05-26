using Hatfield.EnviroData.DataAcquisition.XML.Parsers;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML.Test
{
    [TestFixture]
    public class XMLParserTest
    {
        [Test]
        public void NotSupportDataSourceLocationTest()
        {
            var mockDataSourceLocation = new Mock<IDataSourceLocation>();
            var mockDataToImport = new Mock<IDataToImport>();

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new ElementParser(parserFactory);

            var testParsingResult = testCellParser.Parse(mockDataToImport.Object, mockDataSourceLocation.Object, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            Assert.AreEqual("Castle.Proxies.IDataSourceLocationProxy is not supported by XML Node Parser", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void NotSupportDataSourceTest()
        {
            var dataSourceLocation = new XMLDataSourceLocation("", "");
            var mockDataToImport = new Mock<IDataToImport>();

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new ElementParser(parserFactory);

            var testParsingResult = testCellParser.Parse(mockDataToImport.Object, dataSourceLocation, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            Assert.AreEqual("Castle.Proxies.IDataToImportProxy is not supported by XML Node Parser", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void OutOfRangeTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataSourceLocation = new XMLDataSourceLocation("here","there");
            var dataToImport = new XMLDataToImport(dataFromFileSystem);
                                                    
            var parserFactory = new DefaultParserFactory();

            var testElementParser = new ElementParser(parserFactory);

            var testParsingResult = testElementParser.Parse(dataToImport, dataSourceLocation, typeof(int)) as ParsingResult;


            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.FATAL, testParsingResult.Level);
            //Assert.AreEqual("Argument is out of range", testParsingResult.Message);
            Assert.Null(testParsingResult.Value);
        }

        [Test]
        public void ParsingSuccessTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new XMLDataToImport(dataFromFileSystem);

            var dataSourceLocation = new XMLDataSourceLocation("LabReport", "Lab_Report_Number");

            var parserFactory = new DefaultParserFactory();

            var testCellParser = new ElementParser(parserFactory);

            var testParsingResult = testCellParser.Parse(dataToImport, dataSourceLocation, typeof(string)) as ParsingResult;

            Assert.NotNull(testParsingResult);
            Assert.AreEqual(ResultLevel.INFO, testParsingResult.Level);
            Assert.AreEqual("Parsing value successfully", testParsingResult.Message);
            Assert.AreEqual("LR04927",testParsingResult.Value);
        }
    }
}
