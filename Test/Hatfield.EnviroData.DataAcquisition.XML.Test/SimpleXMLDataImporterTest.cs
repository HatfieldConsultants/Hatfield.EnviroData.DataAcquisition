using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.XML.Test
{
    [TestFixture]
    public class SimpleXMLDataImporterTest
    {
        [Test]
        public void ExtractDataTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new XMLDataToImport(dataFromFileSystem);

            var dataImporter = new TestXMLImporterBuilder().Build();

            var extractedDataSet = dataImporter.Extract<ESDATModel>(dataToImport);

            Assert.NotNull(extractedDataSet);
            Assert.AreEqual(true, extractedDataSet.IsExtractedSuccess);
            Assert.AreEqual(1, extractedDataSet.ExtractedEntities.Count());

        }


        private IDataToImport GetDataToImport(string fileName)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", fileName);
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();

            var dataToImport = new XMLDataToImport(dataFromFileSystem);

            return dataToImport;
        }

        //[Test]
        //public void ExtractDataNotValidFormatTest()
        //{
        //    var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "CSV_15min.csv");
        //    var dataSource = new WindowsFileSystem(path);
        //    var dataFromFileSystem = dataSource.FetchData();

        //    var dataToImport = new XMLDataToImport(dataFromFileSystem);

        //    var dataImporter = new TestXMLImporterBuilder().Build();

        //    var extractedDataSet = dataImporter.Extract<ESDATModel>(dataToImport);

        //    Assert.NotNull(extractedDataSet);
        //    Assert.AreEqual(false, extractedDataSet.IsExtractedSuccess);
        //    Assert.Null(extractedDataSet.ExtractedEntities);
        //}
    }
}
