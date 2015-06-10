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

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Test.Converters.ESDATConverter.ODM2Converter
{
    [TestFixture]
    class ODM2MapperTest
    {
        [Test]
        public void Test()
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

            var esdatModel = extractResult.ExtractedEntities.First();

            var mockDb = new Mock<IDbContext>();

            // Variables
            var _sampleVariable = new Variable();
            _sampleVariable.VariableID = 101;
            _sampleVariable.VariableTypeCV = "Sample";
            _sampleVariable.VariableCode = string.Empty;
            _sampleVariable.VariableNameCV = string.Empty;
            _sampleVariable.SpeciationCV = "notApplicable";
            _sampleVariable.NoDataValue = -9999;

            var _chemistryVariable1 = new Variable();
            _chemistryVariable1.VariableID = 102;
            _chemistryVariable1.VariableTypeCV = "Chemistry";
            _chemistryVariable1.VariableCode = string.Empty;
            _chemistryVariable1.VariableNameCV = "Ethylbenzene";
            _chemistryVariable1.SpeciationCV = "notApplicable";
            _chemistryVariable1.NoDataValue = -9999;

            var _chemistryVariable2 = new Variable();
            _chemistryVariable2.VariableID = 103;
            _chemistryVariable2.VariableTypeCV = "Chemistry";
            _chemistryVariable2.VariableCode = string.Empty;
            _chemistryVariable2.VariableNameCV = "Toluene";
            _chemistryVariable2.SpeciationCV = "notApplicable";
            _chemistryVariable2.NoDataValue = -9999;

            var _chemistryVariable3 = new Variable();
            _chemistryVariable3.VariableID = 104;
            _chemistryVariable3.VariableTypeCV = "Chemistry";
            _chemistryVariable3.VariableCode = string.Empty;
            _chemistryVariable3.VariableNameCV = "Xylenes";
            _chemistryVariable3.SpeciationCV = "notApplicable";
            _chemistryVariable3.NoDataValue = -9999;

            var _chemistryVariable4 = new Variable();
            _chemistryVariable4.VariableID = 105;
            _chemistryVariable4.VariableTypeCV = "Chemistry";
            _chemistryVariable4.VariableCode = string.Empty;
            _chemistryVariable4.VariableNameCV = "Naphthenic Acid";
            _chemistryVariable4.SpeciationCV = "notApplicable";
            _chemistryVariable4.NoDataValue = -9999;

            var _chemistryVariable5 = new Variable();
            _chemistryVariable5.VariableID = 106;
            _chemistryVariable5.VariableTypeCV = "Chemistry";
            _chemistryVariable5.VariableCode = string.Empty;
            _chemistryVariable5.VariableNameCV = "Toluene-d8 (BTEX)";
            _chemistryVariable5.SpeciationCV = "notApplicable";
            _chemistryVariable5.NoDataValue = -9999;

            var _chemistryVariable6 = new Variable();
            _chemistryVariable6.VariableID = 107;
            _chemistryVariable6.VariableTypeCV = "Chemistry";
            _chemistryVariable6.VariableCode = string.Empty;
            _chemistryVariable6.VariableNameCV = "Benzene";
            _chemistryVariable6.SpeciationCV = "notApplicable";
            _chemistryVariable6.NoDataValue = -9999;

            var _chemistryVariable7 = new Variable();
            _chemistryVariable7.VariableID = 108;
            _chemistryVariable7.VariableTypeCV = "Chemistry";
            _chemistryVariable7.VariableCode = string.Empty;
            _chemistryVariable7.VariableNameCV = "o-Terphenyl (F2-F4)";
            _chemistryVariable7.SpeciationCV = "notApplicable";
            _chemistryVariable7.NoDataValue = -9999;

            var _chemistryVariable8 = new Variable();
            _chemistryVariable8.VariableID = 109;
            _chemistryVariable8.VariableTypeCV = "Chemistry";
            _chemistryVariable8.VariableCode = string.Empty;
            _chemistryVariable8.VariableNameCV = "C>10 - C16";
            _chemistryVariable8.SpeciationCV = "notApplicable";
            _chemistryVariable8.NoDataValue = -9999;

            var variableList = new List<Variable>() { _sampleVariable,
                _chemistryVariable1,
                _chemistryVariable2,
                _chemistryVariable3,
                _chemistryVariable4,
                _chemistryVariable5,
                _chemistryVariable6,
                _chemistryVariable7,
                _chemistryVariable8
            }.AsQueryable();
            mockDb.Setup(x => x.Query<Variable>()).Returns(variableList);

            // Unit
            var testUnit0 = new Unit();
            testUnit0.UnitsID = 101;
            testUnit0.UnitsTypeCV = string.Empty;
            testUnit0.UnitsAbbreviation = string.Empty;
            testUnit0.UnitsName = string.Empty;

            var testUnit1 = new Unit();
            testUnit1.UnitsID = 102;
            testUnit1.UnitsTypeCV = "mg/L";
            testUnit1.UnitsAbbreviation = "mg";
            testUnit1.UnitsName = "mg/L";

            var testUnit2 = new Unit();
            testUnit2.UnitsID = 103;
            testUnit2.UnitsTypeCV = "ug/mL";
            testUnit2.UnitsAbbreviation = "ug";
            testUnit2.UnitsName = "ug/mL";

            var testUnit3 = new Unit();
            testUnit3.UnitsID = 104;
            testUnit3.UnitsTypeCV = "%";
            testUnit3.UnitsAbbreviation = "%";
            testUnit3.UnitsName = "%";

            var unitList = new List<Unit>() { testUnit0, testUnit1, testUnit2, testUnit3 }.AsQueryable();
            mockDb.Setup(x => x.Query<Unit>()).Returns(unitList);

            // Sampling Feature
            var sampleSamplingFeature1 = new SamplingFeature();
            sampleSamplingFeature1.SamplingFeatureID = 101;
            sampleSamplingFeature1.SamplingFeatureTypeCV = "Site";
            sampleSamplingFeature1.SamplingFeatureCode = string.Empty;

            var sampleSamplingFeature2 = new SamplingFeature();
            sampleSamplingFeature2.SamplingFeatureID = 102;
            sampleSamplingFeature2.SamplingFeatureTypeCV = "Specimen";
            sampleSamplingFeature2.SamplingFeatureCode = string.Empty;

            var samplingFeatureList = new List<SamplingFeature>() { sampleSamplingFeature1, sampleSamplingFeature2 }.AsQueryable();
            mockDb.Setup(x => x.Query<SamplingFeature>()).Returns(samplingFeatureList);

            // Processing Level
            var processingLevel1 = new ProcessingLevel();
            processingLevel1.ProcessingLevelID = 101;
            processingLevel1.ProcessingLevelCode = string.Empty;

            var processignLevelList = new List<ProcessingLevel>() { processingLevel1 }.AsQueryable();
            mockDb.Setup(x => x.Query<ProcessingLevel>()).Returns(processignLevelList);

            // Person
            var _person = new Person();
            _person.PersonID = 101;
            _person.PersonFirstName = string.Empty;
            _person.PersonLastName = string.Empty;

            var personList = new List<Person>() { _person }.AsQueryable();
            mockDb.Setup(x => x.Query<Person>()).Returns(personList);

            // Organization
            var _organization = new Organization();
            _organization.OrganizationID = 101;
            _organization.OrganizationTypeCV = "Company";
            _organization.OrganizationCode = "AGA";
            _organization.OrganizationName = "AGAT";

            var organizationList = new List<Organization>() { _organization }.AsQueryable();
            mockDb.Setup(x => x.Query<Organization>()).Returns(organizationList);

            // Method
            var _sampleCollectionMethod = new Method();
            _sampleCollectionMethod = new Method();
            _sampleCollectionMethod.MethodID = 101;
            _sampleCollectionMethod.MethodTypeCV = "fieldActivity";
            _sampleCollectionMethod.MethodCode = string.Empty;
            _sampleCollectionMethod.MethodName = "Sample Collection";

            var _chemistryMethod1 = new Method();
            _chemistryMethod1.MethodID = 102;
            _chemistryMethod1.MethodTypeCV = "specimenAnalysis";
            _chemistryMethod1.MethodCode = string.Empty;
            _chemistryMethod1.MethodName = "TO 0332";

            var _chemistryMethod2 = new Method();
            _chemistryMethod2.MethodID = 103;
            _chemistryMethod2.MethodTypeCV = "specimenAnalysis";
            _chemistryMethod2.MethodCode = string.Empty;
            _chemistryMethod2.MethodName = "TO 2220";

            var _chemistryMethod3 = new Method();
            _chemistryMethod3.MethodID = 104;
            _chemistryMethod3.MethodTypeCV = "specimenAnalysis";
            _chemistryMethod3.MethodCode = string.Empty;
            _chemistryMethod3.MethodName = "TO 0540";

            var _chemistryMethod4 = new Method();
            _chemistryMethod4.MethodID = 105;
            _chemistryMethod4.MethodTypeCV = "specimenAnalysis";
            _chemistryMethod4.MethodCode = string.Empty;
            _chemistryMethod4.MethodName = "TO 0511";

            // Set up a mock database with dummy list
            var methodList = new List<Method>() {
                _sampleCollectionMethod,
                _chemistryMethod1,
                _chemistryMethod2,
                _chemistryMethod3,
                _chemistryMethod4
            }.AsQueryable();
            mockDb.Setup(x => x.Query<Method>()).Returns(methodList);

            // Create sample collection action
            var mockDbContext = mockDb.Object;
            var duplicateChecker = new DuplicateChecker(mockDbContext);
            var converterFactory = new ESDATDataMapperFactory(mockDbContext, duplicateChecker);

            var actionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Core.Action)) as ActionMapper;
            var sampleAction = actionConverter.Map(esdatModel, converterFactory);

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
            var datasetConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DatasetMapper;
            Assert.AreEqual(datasetConverter.ToGuid(0), dataset.DataSetUUID);
            Assert.AreEqual("other", dataset.DataSetTypeCV);
            Assert.AreEqual(string.Empty, dataset.DataSetCode);
            Assert.AreEqual(string.Empty, dataset.DataSetTitle);
            Assert.AreEqual(string.Empty, dataset.DataSetAbstract);
            Assert.IsTrue(dataset.DataSetsResults.Contains(dataSetsResult));
        }
    }
}
