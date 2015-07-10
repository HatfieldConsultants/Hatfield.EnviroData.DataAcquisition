using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Importer;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using System.IO;

using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ESDATConverterTest
    {
        //Commment this out so auto-build would not run this unit test
        //[Test]
        public void MapTest()
        {
            var dbContext = new ODM2Entities();
            var duplicateChecker = new ESDATDuplicateChecker(dbContext);
            var esdatModel = extractEsdatModel();
            var WQDefaultValueProvider = new StaticWQDefaultValueProvider();
            var wayToHandleNewData = WayToHandleNewData.ThrowExceptionForNewData;

            var sampleCollectionFactory = new ESDATSampleCollectionMapperFactory(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            var chemistryFactory = new ESDATChemistryMapperFactory(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            var mapper = new SampleCollectionActionMapper(duplicateChecker, sampleCollectionFactory, WQDefaultValueProvider, chemistryFactory, wayToHandleNewData);

            var converter = new ESDATConverter(mapper);
            var action = converter.Convert(esdatModel);

            dbContext.Add(action);
            dbContext.SaveChanges();
        }

        private ESDATModel extractEsdatModel()
        {
            var mockDefaultValueProvider = new Mock<IWQDefaultValueProvider>();

            var headerFileToImport = ESDATTestHelper.CreateXMLDatoToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml"));
            var chemistryFileToImport = ESDATTestHelper.CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv"));
            var sampleFileToImport = ESDATTestHelper.CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv"));

            var testESDATDataToImport = new ESDATDataToImport(headerFileToImport, sampleFileToImport, chemistryFileToImport);


            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();
            var sampleFileChildObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            var chemistryDataImporter = ESDATTestHelper.BuildChemistryFileImporter();
            var chemistryFileChildObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryDataImporter, "ChemistryData", simpleValueAssginer);

            var testESDATDataImporter = new ESDATDataImporter(ResultLevel.ERROR, mockDefaultValueProvider.Object);

            ESDATTestHelper.AddXMLExtractConfigurationsToImporter(testESDATDataImporter);
            testESDATDataImporter.AddExtractConfiguration(sampleFileChildObjectExtractConfiguration);
            testESDATDataImporter.AddExtractConfiguration(chemistryFileChildObjectExtractConfiguration);

            var extractResult = testESDATDataImporter.Extract<ESDATModel>(testESDATDataToImport);

            return extractResult.ExtractedEntities.First();
        }
    }
}