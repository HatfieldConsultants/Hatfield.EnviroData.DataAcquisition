using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToAction : ESDATConverterToODMAction
    {
        // Sample Collection Constants
        private const string ActionTypeCVSampleCollection = "specimenCollection";

        // Chemistry Constants
        private const string ActionTypeCVChemistry = "specimenAnalysis";

        public ESDATConverterToAction(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Core.Action Convert(ESDATModel esdatModel, ESDATConverterToActionBy actionByConverter, ESDATConverterToFeatureAction featureActionConverter, ESDATConverterToMethod methodConverter, ESDATConverterToOrganization organizationConverter, ESDATConverterToAffiliation affiliationConverter, ESDATConverterToPerson personConverter, ESDATConverterToRelatedAction relatedActionConverter, ESDATConverterToSamplingFeature samplingFeatureConverter, ESDATConverterToResult resultConverter, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            Core.Action sampleCollectionAction = new Core.Action();

            // Set Member Variables
            sampleCollectionAction.ActionTypeCV = ActionTypeCVSampleCollection;
            sampleCollectionAction.BeginDateTime = esdatModel.DateReported;

            // Feature Actions
            var featureAction = featureActionConverter.Convert(esdatModel, samplingFeatureConverter, resultConverter, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);
            sampleCollectionAction.FeatureActions.Add(featureAction);

            // Action Bies
            ActionBy actionBy = actionByConverter.Convert(sampleCollectionAction, affiliationConverter, personConverter);
            sampleCollectionAction.ActionBies.Add(actionBy);

            // Method
            sampleCollectionAction.Method = methodConverter.Convert(esdatModel, organizationConverter, affiliationConverter, personConverter);

            // Related Actions
            foreach(ChemistryFileData chemistry in esdatModel.ChemistryData)
            {
                Core.Action chemistryAction = this.Convert(chemistry, sampleCollectionAction, actionByConverter, featureActionConverter, methodConverter, organizationConverter, affiliationConverter, personConverter, relatedActionConverter, samplingFeatureConverter, resultConverter, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);

                RelatedAction relatedAction = relatedActionConverter.Convert(sampleCollectionAction, chemistryAction, "isParentOf");
                sampleCollectionAction.RelatedActions.Add(relatedAction);
            }

            return sampleCollectionAction;
        }

        public Core.Action Convert(ChemistryFileData chemistry, Core.Action sampleCollectionAction, ESDATConverterToActionBy actionByConverter, ESDATConverterToFeatureAction featureActionConverter, ESDATConverterToMethod methodConverter, ESDATConverterToOrganization organizationConverter, ESDATConverterToAffiliation affiliationConverter, ESDATConverterToPerson personConverter, ESDATConverterToRelatedAction relatedActionConverter, ESDATConverterToSamplingFeature samplingFeatureConverter, ESDATConverterToResult resultConverter, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            Core.Action chemistryAction = new Core.Action();

            // Set Member Variables
            chemistryAction.ActionTypeCV = ActionTypeCVChemistry;
            chemistryAction.BeginDateTime = chemistry.AnalysedDate;

            // Feature Actions
            var featureAction = featureActionConverter.Convert(chemistry, samplingFeatureConverter, resultConverter, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);
            chemistryAction.FeatureActions.Add(featureAction);

            // Action Bies
            ActionBy actionBy = actionByConverter.Convert(chemistryAction, affiliationConverter, personConverter);
            chemistryAction.ActionBies.Add(actionBy);

            // Method
            chemistryAction.Method = methodConverter.Convert(chemistry, organizationConverter, affiliationConverter, personConverter);

            // Related Actions
            if (sampleCollectionAction != null)
            {
                RelatedAction relatedAction = relatedActionConverter.Convert(chemistryAction, sampleCollectionAction, "isChildOf");
                chemistryAction.RelatedActions.Add(relatedAction);
            }
            
            return chemistryAction;
        }
    }
}
