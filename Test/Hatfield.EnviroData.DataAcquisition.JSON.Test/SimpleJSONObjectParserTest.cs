using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition;
using Hatfield.EnviroData.DataAcquisition.JSON;
using Hatfield.EnviroData.DataAcquisition.JSON.Parsers;
using Hatfield.EnviroData.FileSystems;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;

namespace Hatfield.EnviroData.DataAcquisition.JSON.Test
{
    [TestFixture]
    public class SimpleJSONObjectParserTest
    {
        [Test]
        public void ParseTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "TestJSONFile.json");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataSourceLocation = new JSONDataSourceLocation("objects[*].name", true);
            var dataToImport = new JSONDataToImport(dataFromFileSystem);

            var parserFactory = new DefaultParserFactory();

            var testParser = new SimpleJSONObjectParser(parserFactory);

            var parseResults = testParser.Parse(dataToImport, dataSourceLocation, typeof(string)) as ParsingResult;

            dynamic result = parseResults.Value;

            Assert.NotNull(parseResults);
            Assert.AreEqual("Cruise", result[0]);
            Assert.AreEqual("Data retrieval", result[1]);
            Assert.AreEqual("Derivation", result[2]);
            
        }
    }
}
