using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public static class ODM2EntityLinker
    {
        public static void Link(Result result, Unit unit)
        {
            result.Unit = unit;
            result.UnitsID = unit.UnitsID;

            unit.Results.Add(result);
        }

        public static void Link(Result result, ProcessingLevel processingLevel)
        {
            result.ProcessingLevel = processingLevel;
            result.ProcessingLevelID = processingLevel.ProcessingLevelID;

            processingLevel.Results.Add(result);
        }

        public static void Link(Result result, Variable variable)
        {
            result.Variable = variable;
            result.VariableID = variable.VariableID;

            variable.Results.Add(result);
        }

        public static void Link(Result result, DatasetsResult datasetsResult)
        {
            result.DatasetsResults.Add(datasetsResult);

            datasetsResult.Result = result;
            datasetsResult.ResultID = result.ResultID;
        }

        public static void Link(Result result, MeasurementResult measurementResult)
        {
            result.MeasurementResult = measurementResult;

            measurementResult.Result = result;
            measurementResult.ResultID = result.ResultID;
        }

        public static void Link(MeasurementResult measurementResult, Unit unit)
        {
            measurementResult.Unit = unit;

            unit.MeasurementResults.Add(measurementResult);
        }

        public static void Link(ActionBy actionBy, Affiliation affiliation)
        {
            actionBy.Affiliation = affiliation;
            actionBy.AffiliationID = affiliation.AffiliationID;

            affiliation.ActionBies.Add(actionBy);
        }

        public static void Link(Core.Action action, FeatureAction featureAction)
        {
            action.FeatureActions.Add(featureAction);

            featureAction.Action = action;
            featureAction.ActionID = action.ActionID;
        }

        public static void Link(Core.Action action, ActionBy actionBy)
        {
            action.ActionBies.Add(actionBy);

            actionBy.Action = action;
            actionBy.ActionID = action.ActionID;
        }

        public static void Link(Core.Action action, Method method)
        {
            action.Method = method;
            action.MethodID = method.MethodID;

            method.Actions.Add(action);
        }

        public static void Link(Core.Action action, RelatedAction relatedAction)
        {
            action.RelatedActions.Add(relatedAction);

            relatedAction.Action = action;
            relatedAction.ActionID = action.ActionID;
        }

        public static void Link(Affiliation affiliation, Person person)
        {
            affiliation.Person = person;
            affiliation.PersonID = person.PersonID;

            person.Affiliations.Add(affiliation);
        }

        public static void Link(DatasetsResult datasetsResult, Dataset dataset)
        {
            datasetsResult.Dataset = dataset;
            datasetsResult.DatasetID = dataset.DatasetID;

            dataset.DatasetsResults.Add(datasetsResult);
        }

        public static void Link(FeatureAction featureAction, SamplingFeature samplingFeature)
        {
            featureAction.SamplingFeature = samplingFeature;
            featureAction.SamplingFeatureID = samplingFeature.SamplingFeatureID;

            samplingFeature.FeatureActions.Add(featureAction);
        }

        public static void Link(FeatureAction featureAction, Result result)
        {
            featureAction.Results.Add(result);

            result.FeatureAction = featureAction;
            result.FeatureActionID = featureAction.FeatureActionID;
        }

        public static void Link(MeasurementResult measurementResult, MeasurementResultValue measurementResultValue)
        {
            measurementResult.MeasurementResultValues.Add(measurementResultValue);

            measurementResultValue.MeasurementResult = measurementResult;
        }

        public static void Link(Organization organization, Affiliation affiliation)
        {
            organization.Affiliations.Add(affiliation);

            affiliation.Organization = organization;
            affiliation.OrganizationID = organization.OrganizationID;
        }

        public static void Link(Method method, Organization organization)
        {
            method.Organization = organization;
            method.OrganizationID = organization.OrganizationID;

            organization.Methods.Add(method);
        }
    }
}
