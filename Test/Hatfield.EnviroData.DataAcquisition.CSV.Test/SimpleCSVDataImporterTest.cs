using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;
using Hatfield.EnviroData.DataAcquisition.CSV.Parsers;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Test
{
    [TestFixture]
    public class SimpleCSVDataImporterTest
    {
        [Test]
        public void ExtractDataTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "DAT_15min.dat");
            var dataSource = new CSVDataSource(path);

            var dataToImport = dataSource.FetchData();

            
            var dataImporter = new TestImporterBuilder().Build();

            var extractedDataSet = dataImporter.Extract<TestDataModel>(dataToImport);

            Assert.NotNull(extractedDataSet);
            Assert.AreEqual(true, extractedDataSet.IsExtractedSuccess);
            Assert.AreEqual(12, extractedDataSet.ExtractedEntities.Count());

        }
    }

}
