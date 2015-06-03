using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionConverter : ODM2ConverterBase
    {
        // Sample Collection Constants
        private const string ActionTypeCVSampleCollection = "specimenCollection";
        private const string isRelatedToCV = "isRelatedTo";

        // Chemistry Constants
        private const string ActionTypeCVChemistry = "specimenAnalysis";
        private const string isChildOfCV = "isChildOf";

        public ActionConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Core.Action Convert(ESDATModel esdatModel, IESDATDataConverterFactory converterFactory)
        {
            Core.Action action = new Core.Action();

            // Set Member Variables
            action.ActionTypeCV = ActionTypeCVSampleCollection;
            action.BeginDateTime = esdatModel.DateReported;

            // Feature Actions
            var featureActionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionConverter;
            var featureAction = featureActionConverter.Convert(esdatModel, converterFactory);
            action.FeatureActions.Add(featureAction);

            // Action Bies
            var actionByConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ActionBy)) as ActionByConverter;
            ActionBy actionBy = actionByConverter.Convert(action, converterFactory);
            action.ActionBies.Add(actionBy);

            // Method
            var methodConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Method)) as MethodConverter;
            action.Method = methodConverter.Convert(esdatModel, converterFactory);

            // Related Actions
            var relatedActionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(RelatedAction)) as RelatedActionConverter;

            foreach(ChemistryFileData chemistry in esdatModel.ChemistryData)
            {
                Core.Action chemistryAction = this.Convert(chemistry, esdatModel, action, converterFactory);

                RelatedAction relatedAction = relatedActionConverter.Convert(action, isRelatedToCV, chemistryAction);
                action.RelatedActions.Add(relatedAction);
            }

            return action;
        }

        public Core.Action Convert(ChemistryFileData chemistry, ESDATModel esdatModel, Core.Action parentAction, IESDATDataConverterFactory converterFactory)
        {
            Core.Action action = new Core.Action();

            // Set Member Variables
            action.ActionTypeCV = ActionTypeCVChemistry;
            action.BeginDateTime = chemistry.AnalysedDate;

            // Feature Actions
            var featureActionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionConverter;
            var featureAction = featureActionConverter.Convert(chemistry, converterFactory);
            action.FeatureActions.Add(featureAction);

            // Action Bies
            var actionByConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ActionBy)) as ActionByConverter;
            ActionBy actionBy = actionByConverter.Convert(action, converterFactory);
            action.ActionBies.Add(actionBy);

            // Method
            var methodConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Method)) as MethodConverter;
            action.Method = methodConverter.Convert(chemistry, converterFactory);

            // Related Actions
            var relatedActionConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(RelatedAction)) as RelatedActionConverter;

            if (parentAction != null)
            {
                RelatedAction relatedAction = relatedActionConverter.Convert(action, isChildOfCV, parentAction);
                action.RelatedActions.Add(relatedAction);
            }
            
            return action;
        }
    }
}
