using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.XML;
using Hatfield.EnviroData.DataAcquisition.CSV;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class ESDATDataToImportTest
    {
        [Test]
        public void GetDataTest()
        {
            var xmlDataToImport = new XMLDataToImport("test.xml", new System.Xml.Linq.XDocument());
            var csvDataToImport1 = new CSVDataToImport("test1.csv", new string[][]{});
            var csvDataToImport2 = new CSVDataToImport("test2.csv", new string[][] { });

            var dataToImport = new ESDATDataToImport(xmlDataToImport, csvDataToImport1, csvDataToImport2);

            Assert.AreEqual(dataToImport, dataToImport.Data);
        }
    }
}
