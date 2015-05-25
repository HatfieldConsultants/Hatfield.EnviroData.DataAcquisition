using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.Criterias;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.CSV.Importers;
using Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules;
using Hatfield.EnviroData.DataAcquisition.ESDAT;
using Hatfield.EnviroData.DataAcquisition.CSV;
using Hatfield.EnviroData.FileSystems.WindowsFileSystem;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test
{
    [TestFixture]
    public class ChemistryFileChildPropertyExtractConfigurationTest
    {
        [Test]
        public void ChemistryFilePropertyTest()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv");
            var dataSource = new WindowsFileSystem(path);
            var dataFromFileSystem = dataSource.FetchData();
            var dataToImport = new CSVDataToImport(dataFromFileSystem);

            var simpleValueAssginer = new SimpleValueAssigner();

            var chemistryImporter = ESDATTestHelper.BuildChemistryFileImporter();

            var childObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryImporter, "ChemistryData", simpleValueAssginer);

            var testESDATModel = new ESDATModel();

            var extractResult = childObjectExtractConfiguration.ExtractData(testESDATModel, dataToImport);

            Assert.NotNull(extractResult);
            Assert.AreEqual(9, testESDATModel.ChemistryData.Count());
        }
    }
}
