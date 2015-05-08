using Hatfield.EnviroData.DataAcquisition.FileSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Hatfield.EnviroData.DataAcquisition.XML.Test
{
    [TestFixture]
    public class XMLDataToImportTest
    {
        private string _xmlDataFilePath;
        private string _datDataFilePath;

        [TestFixtureSetUp]
        public void Setup()
        {
            _xmlDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml");
            //_datDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");
        }

        [Test]
        public void CSVDataToImportReadCSVFileTest()
        {
            var dataSource = new LocalFileSystem(_xmlDataFilePath);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new XMLDataToImport(dataFromFileSystem);
            AssertData(Path.GetFileName(_xmlDataFilePath), dataToImport);
        }

        private void AssertData(string fileName, XMLDataToImport xmlDataToImport)
        {
            Assert.AreEqual(fileName, xmlDataToImport.FileName);
            Assert.NotNull(xmlDataToImport);
            var data = xmlDataToImport.Data;
            Assert.NotNull(data);
        }
    }
}


