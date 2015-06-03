using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;
using System.Data.Entity.Validation;
using Hatfield.EnviroData.DataAcquisition.ValueAssigners;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Importer;
using System.IO;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters
{
    [TestFixture]
    class ActionConverterTest
    {
        [Test]
        public void ChemistryTest()
        {
            var chemistry = new ChemistryFileData();
            var esdatModel = new ESDATModel();
            chemistry.AnalysedDate = DateTime.Now;
            var parentAction = new Core.Action();
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var actionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Core.Action)) as ActionConverter;
            Core.Action action = actionConverter.Convert(chemistry, esdatModel, parentAction, converterFactory);

            Assert.AreEqual(0, action.ActionID);
            Assert.AreEqual("specimenAnalysis", action.ActionTypeCV);
            Assert.AreEqual(0, action.MethodID);
            Assert.AreEqual(chemistry.AnalysedDate, action.BeginDateTime);
            Assert.AreEqual(0, action.BeginDateTimeUTCOffset);
            Assert.AreEqual(null, action.EndDateTime);
            Assert.AreEqual(null, action.EndDateTimeUTCOffset);
            Assert.AreEqual(null, action.ActionDescription);
            Assert.AreEqual(null, action.ActionFileLink);
        }

        [Test]
        public void SaveChemistryActionToDBTest()
        {
            var esdatModel = this.getEsdatModel();

            // Create sample collection action
            var mockDbContext = new Mock<IDbContext>().Object;
            var converterFactory = new ESDATDataConverterFactory(mockDbContext);
            var actionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Core.Action)) as ActionConverter;
            var sampleAction = actionConverter.Convert(esdatModel, converterFactory);

            // Get first chemistry action
            Core.Action chemistryAction = sampleAction.RelatedActions.FirstOrDefault().Action1;
            var chemistry = esdatModel.ChemistryData.FirstOrDefault();

            // Action By > Affiliation > People tree
            var actionBy = chemistryAction.ActionBies.FirstOrDefault();
            var affiliation = actionBy.Affiliation;
            var person = affiliation.Person;

            // Action By
            Assert.AreEqual(chemistryAction.ActionID, actionBy.ActionID);
            Assert.AreEqual(affiliation.AffiliationID, actionBy.AffiliationID);
            Assert.AreEqual(true, actionBy.IsActionLead);
            Assert.AreEqual(null, actionBy.RoleDescription);
            Assert.AreEqual(chemistryAction, actionBy.Action);

            // Related Actions tree
            var relatedAction = chemistryAction.RelatedActions.FirstOrDefault();

            // Related Actions
            Assert.AreEqual(chemistryAction.ActionID, chemistryAction.ActionID);
            Assert.AreEqual("isChildOf", relatedAction.RelationshipTypeCV);
            Assert.AreEqual(sampleAction.ActionID, relatedAction.RelatedActionID);
            Assert.AreEqual(chemistryAction, relatedAction.Action);
            Assert.AreEqual(sampleAction, relatedAction.Action1);

            // Affiliation
            Assert.AreEqual(person.PersonID, affiliation.PersonID);
            Assert.AreEqual(null, affiliation.OrganizationID);
            Assert.AreEqual(null, affiliation.IsPrimaryOrganizationContact);
            Assert.AreEqual(null, affiliation.AffiliationEndDate);
            Assert.AreEqual(null, affiliation.PrimaryPhone);
            Assert.AreEqual(string.Empty, affiliation.PrimaryEmail);
            Assert.AreEqual(null, affiliation.PrimaryAddress);
            Assert.AreEqual(null, affiliation.PersonLink);
            Assert.IsTrue(affiliation.ActionBies.Contains(actionBy));

            // Person
            Assert.AreEqual(string.Empty, person.PersonFirstName);
            Assert.AreEqual(null, person.PersonMiddleName);
            Assert.AreEqual(string.Empty, person.PersonLastName);
            Assert.IsTrue(person.Affiliations.Contains(affiliation));

            // Feature Actions > Sampling Features tree
            var featureAction = chemistryAction.FeatureActions.FirstOrDefault();
            var samplingFeature = featureAction.SamplingFeature;

            // Feature Action
            Assert.AreEqual(samplingFeature.SamplingFeatureID, featureAction.SamplingFeatureID);
            Assert.AreEqual(chemistryAction.ActionID, featureAction.ActionID);

            // Sampling Feature
            Assert.AreEqual("Specimen", samplingFeature.SamplingFeatureTypeCV);
            Assert.AreEqual(string.Empty, samplingFeature.SamplingFeatureCode);
            Assert.AreEqual(null, samplingFeature.SamplingFeatureGeotypeCV);
            Assert.AreEqual(null, samplingFeature.FeatureGeometry);
            Assert.AreEqual(null, samplingFeature.ElevationDatumCV);
            Assert.IsTrue(samplingFeature.FeatureActions.Contains(featureAction));

            // Feature Actions > Results tree
            var result = featureAction.Results.FirstOrDefault();
            var variable = result.Variable;
            var unit = result.Unit;
            var processingLevel = result.ProcessingLevel;
            var dataSetsResult = result.DataSetsResults.FirstOrDefault();
            var dataset = dataSetsResult.DataSet;

            // Result
            Assert.AreEqual(featureAction.FeatureActionID, result.FeatureActionID);
            Assert.AreEqual("measurement", result.ResultTypeCV);
            Assert.AreEqual(variable.VariableID, result.VariableID);
            Assert.AreEqual(unit.UnitsID, result.UnitsID);
            Assert.AreEqual(processingLevel.ProcessingLevelID, result.ProcessingLevelID);
            Assert.AreEqual(chemistry.AnalysedDate, result.ResultDateTime);
            Assert.AreEqual(null, result.ValidDateTime);
            Assert.AreEqual(null, result.ValidDateTimeUTCOffset);
            Assert.AreEqual(null, result.StatusCV);
            Assert.AreEqual("liquidAqueous", result.SampledMediumCV);
            Assert.AreEqual(1, result.ValueCount);

            // Variable
            Assert.AreEqual("Chemistry", variable.VariableTypeCV);
            Assert.AreEqual(string.Empty, variable.VariableCode);
            Assert.AreEqual(chemistry.OriginalChemName, variable.VariableNameCV);
            Assert.AreEqual(null, variable.VariableDefinition);
            Assert.AreEqual("notApplicable", variable.SpeciationCV);
            Assert.AreEqual(-9999, variable.NoDataValue);
            Assert.IsTrue(variable.Results.Contains(result));

            // Unit
            Assert.AreEqual(chemistry.ResultUnit, unit.UnitsTypeCV);
            Assert.AreEqual(chemistry.ResultUnit.Substring(0, 2), unit.UnitsAbbreviation);
            Assert.AreEqual(chemistry.ResultUnit, unit.UnitsName);
            Assert.IsTrue(unit.Results.Contains(result));

            // Processing Level
            Assert.AreEqual(string.Empty, processingLevel.ProcessingLevelCode);
            Assert.AreEqual(null, processingLevel.Definition);
            Assert.AreEqual(null, processingLevel.Explanation);
            Assert.IsTrue(processingLevel.Results.Contains(result));

            // Dataset Results
            Assert.AreEqual(dataset.DataSetID, dataSetsResult.DataSetID);
            Assert.AreEqual(result.ResultID, dataSetsResult.ResultID);
            Assert.AreEqual(result, dataSetsResult.Result);

            // Dataset
            var datasetConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DataSetConverter;
            Assert.AreEqual(datasetConverter.ToGuid(0), dataset.DataSetUUID);
            Assert.AreEqual("other", dataset.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataset.DataSetCode);
            Assert.AreEqual(string.Empty, dataset.DataSetTitle);
            Assert.AreEqual(string.Empty, dataset.DataSetAbstract);
            Assert.IsTrue(dataset.DataSetsResults.Contains(dataSetsResult));
        }

        private ESDATModel getEsdatModel()
        {
            var headerFileToImport = ESDATTestHelper.CreateXMLDatoToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "XMLSample.xml"));
            var chemistryFileToImport = ESDATTestHelper.CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "ChemistryFileExample.csv"));
            var sampleFileToImport = ESDATTestHelper.CreateCSVDataToImport(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "SampleFileExample.csv"));

            var testESDATDataToImport = new ESDATDataToImport(headerFileToImport, sampleFileToImport, chemistryFileToImport);

            var simpleValueAssginer = new SimpleValueAssigner();

            var sampleDataImporter = ESDATTestHelper.BuildSampleDataFileImporter();
            var sampleFileChildObjectExtractConfiguration = new SampleFileChildObjectExtractConfiguration(sampleDataImporter, "SampleFileData", simpleValueAssginer);

            var chemistryDataImporter = ESDATTestHelper.BuildChemistryFileImporter();
            var chemistryFileChildObjectExtractConfiguration = new ChemistryFileChildObjectExtractConfiguration(chemistryDataImporter, "ChemistryData", simpleValueAssginer);

            var testESDATDataImporter = new ESDATDataImporter(ResultLevel.ERROR);

            ESDATTestHelper.AddXMLExtractConfigurationsToImporter(testESDATDataImporter);
            testESDATDataImporter.AddExtractConfiguration(sampleFileChildObjectExtractConfiguration);
            testESDATDataImporter.AddExtractConfiguration(chemistryFileChildObjectExtractConfiguration);

            var extractResult = testESDATDataImporter.Extract<ESDATModel>(testESDATDataToImport);

            return extractResult.ExtractedEntities.First();
        }
    }
}
