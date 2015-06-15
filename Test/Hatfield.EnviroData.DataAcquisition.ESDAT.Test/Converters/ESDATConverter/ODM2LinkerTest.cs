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
    class ODM2LinkerTest
    {
        ESDATLinker _linker = new ESDATLinker();

        [Test]
        public void LinkResultWithUnit()
        {
            var result = new Result();
            result.ResultID = 101;

            var unit = new Unit();
            unit.UnitsID = 102;

            _linker.Link(result, unit);

            Assert.AreEqual(unit, result.Unit);
            Assert.AreEqual(102, result.UnitsID);
            Assert.IsTrue(unit.Results.Contains(result));
        }

        [Test]
        public void LinkResultWithProcessingLevel()
        {
            var result = new Result();

            var processingLevel = new ProcessingLevel();
            processingLevel.ProcessingLevelID = 102;

            _linker.Link(result, processingLevel);

            Assert.AreEqual(processingLevel, result.ProcessingLevel);
            Assert.AreEqual(102, result.ProcessingLevelID);
            Assert.IsTrue(processingLevel.Results.Contains(result));
        }

        [Test]
        public void LinkResultWithVariable()
        {
            var result = new Result();

            var variable = new Variable();
            variable.VariableID = 102;

            _linker.Link(result, variable);

            Assert.AreEqual(variable, result.Variable);
            Assert.AreEqual(102, result.VariableID);
            Assert.IsTrue(variable.Results.Contains(result));
        }

        [Test]
        public void LinkResultWithDatasetsResult()
        {
            var result = new Result();
            result.ResultID = 101;

            var datasetsResult = new DatasetsResult();

            _linker.Link(result, datasetsResult);

            Assert.AreEqual(result, datasetsResult.Result);
            Assert.AreEqual(101, datasetsResult.ResultID);
            Assert.IsTrue(result.DatasetsResults.Contains(datasetsResult));
        }

        [Test]
        public void LinkResultWithMeasurementResult()
        {
            var result = new Result();
            result.ResultID = 101;

            var measurementResult = new MeasurementResult();
            _linker.Link(result, measurementResult);

            Assert.AreEqual(measurementResult, result.MeasurementResult);
            Assert.AreEqual(result, measurementResult.Result);
            Assert.AreEqual(101, measurementResult.ResultID);
        }

        [Test]
        public void LinkActionByWithAffiliation()
        {
            var actionBy = new ActionBy();

            var affiliation = new Affiliation();
            affiliation.AffiliationID = 102;

            _linker.Link(actionBy, affiliation);

            Assert.AreEqual(affiliation, actionBy.Affiliation);
            Assert.AreEqual(102, actionBy.AffiliationID);
            Assert.IsTrue(affiliation.ActionBies.Contains(actionBy));
        }

        [Test]
        public void LinkActionWithFeatureAction()
        {
            var action = new Core.Action();
            action.ActionID = 101;

            var featureAction = new FeatureAction();

            _linker.Link(action, featureAction);

            Assert.AreEqual(action, featureAction.Action);
            Assert.AreEqual(101, featureAction.ActionID);
            Assert.IsTrue(action.FeatureActions.Contains(featureAction));
        }

        [Test]
        public void LinkActionWithActionBy()
        {
            var action = new Core.Action();
            action.ActionID = 101;

            var actionBy = new ActionBy();

            _linker.Link(action, actionBy);

            Assert.AreEqual(action, actionBy.Action);
            Assert.AreEqual(101, actionBy.ActionID);
            Assert.IsTrue(action.ActionBies.Contains(actionBy));
        }

        [Test]
        public void LinkActionWithMethod()
        {
            var action = new Core.Action();

            var method = new Method();
            method.MethodID = 102;

            _linker.Link(action, method);

            Assert.AreEqual(method, action.Method);
            Assert.AreEqual(102, action.MethodID);
            Assert.IsTrue(method.Actions.Contains(action));
        }

        [Test]
        public void LinkActionWithRelatedAction()
        {
            var action = new Core.Action();
            action.ActionID = 101;

            var relatedAction = new RelatedAction();

            _linker.Link(action, relatedAction);

            Assert.AreEqual(action, relatedAction.Action);
            Assert.AreEqual(101, relatedAction.ActionID);
            Assert.IsTrue(action.RelatedActions.Contains(relatedAction));
        }

        [Test]
        public void LinkAffiliationWithPerson()
        {
            var affiliation = new Affiliation();

            var person = new Person();
            person.PersonID = 102;

            _linker.Link(affiliation, person);

            Assert.AreEqual(person, affiliation.Person);
            Assert.AreEqual(102, affiliation.PersonID);
            Assert.IsTrue(person.Affiliations.Contains(affiliation));
        }

        [Test]
        public void LinkDatasetsResultWithDataset()
        {
            var datasetsResult = new DatasetsResult();

            var dataset = new Dataset();
            dataset.DatasetID = 102;

            _linker.Link(datasetsResult, dataset);

            Assert.AreEqual(dataset, datasetsResult.Dataset);
            Assert.AreEqual(102, datasetsResult.DatasetID);
            Assert.IsTrue(dataset.DatasetsResults.Contains(datasetsResult));
        }

        [Test]
        public void LinkFeatureActionWithSamplingFeature()
        {
            var featureAction = new FeatureAction();

            var samplingFeature = new SamplingFeature();
            samplingFeature.SamplingFeatureID = 102;

            _linker.Link(featureAction, samplingFeature);

            Assert.AreEqual(samplingFeature, featureAction.SamplingFeature);
            Assert.AreEqual(102, featureAction.SamplingFeatureID);
            Assert.IsTrue(samplingFeature.FeatureActions.Contains(featureAction));
        }

        [Test]
        public void LinkFeatureActionWithResult()
        {
            var featureAction = new FeatureAction();
            featureAction.FeatureActionID = 101;

            var result = new Result();

            _linker.Link(featureAction, result);

            Assert.AreEqual(featureAction, result.FeatureAction);
            Assert.AreEqual(101, result.FeatureActionID);
            Assert.IsTrue(featureAction.Results.Contains(result));
        }

        [Test]
        public void LinkMeasurementResultWithMeasurementResultValue()
        {
            var measurementResult = new MeasurementResult();
            
            var measurementResultValue = new MeasurementResultValue();

            _linker.Link(measurementResult, measurementResultValue);

            Assert.AreEqual(measurementResult, measurementResultValue.MeasurementResult);
            Assert.IsTrue(measurementResult.MeasurementResultValues.Contains(measurementResultValue));
        }

        [Test]
        public void LinkOrganizationWithAffiliation()
        {
            var organization = new Organization();
            organization.OrganizationID = 101;

            var affiliation = new Affiliation();

            _linker.Link(organization, affiliation);

            Assert.AreEqual(organization, affiliation.Organization);
            Assert.AreEqual(101, affiliation.OrganizationID);
            Assert.IsTrue(organization.Affiliations.Contains(affiliation));
        }
    }
}
