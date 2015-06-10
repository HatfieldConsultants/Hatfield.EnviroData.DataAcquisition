using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionMapper : ODM2MapperBase
    {
        // Sample Collection Constants
        private const string ActionTypeCVSampleCollection = "specimenCollection";
        private const string isRelatedToCV = "isRelatedTo";

        // Chemistry Constants
        private const string ActionTypeCVChemistry = "specimenAnalysis";
        private const string isChildOfCV = "isChildOf";

        public ActionMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Core.Action Map(ESDATModel esdatModel, IESDATDataConverterFactory converterFactory)
        {
            var entity = this.Scaffold(esdatModel);

            // Feature Actions
            var featureActionMapper = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionMapper;
            var featureAction = featureActionMapper.Map(esdatModel, converterFactory);
            var featureActions = new List<FeatureAction>();
            featureActions.Add(featureAction);

            // Action Bies
            var actionByMapper = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ActionBy)) as ActionByMapper;
            ActionBy actionBy = actionByMapper.Map(entity, converterFactory);
            var actionBies = new List<ActionBy>();
            actionBies.Add(actionBy);

            // Method
            var methodMapper = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Method)) as MethodMapper;
            var method = methodMapper.Map(esdatModel, converterFactory);

            // Related Actions
            var relatedActionMapper = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(RelatedAction)) as RelatedActionMapper;
            var relatedActions = new List<RelatedAction>();

            foreach(ChemistryFileData chemistry in esdatModel.ChemistryData)
            {
                Core.Action chemistryAction = this.Map(chemistry, esdatModel, entity, converterFactory);

                RelatedAction relatedAction = relatedActionMapper.Map(entity, isRelatedToCV, chemistryAction);
                relatedActions.Add(relatedAction);
            }

            return this.Link(entity, featureActions, actionBies, relatedActions, method);
        }

        public Core.Action Map(ChemistryFileData chemistry, ESDATModel esdatModel, Core.Action parentAction, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(chemistry);

            // Feature Actions
            var featureActionMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(FeatureAction)) as FeatureActionMapper;
            var featureAction = featureActionMapper.Map(chemistry, factory);
            var featureActions = new List<FeatureAction>();
            featureActions.Add(featureAction);

            // Action Bies
            var actionByMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(ActionBy)) as ActionByMapper;
            ActionBy actionBy = actionByMapper.Map(entity, factory);
            var actionBies = new List<ActionBy>();
            actionBies.Add(actionBy);

            // Method
            var methodMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Method)) as MethodMapper;
            var method = methodMapper.Map(chemistry, factory);

            // Related Actions
            var relatedActionMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(RelatedAction)) as RelatedActionMapper;
            var relatedActions = new List<RelatedAction>();

            if (parentAction != null)
            {
                RelatedAction relatedAction = relatedActionMapper.Map(entity, isChildOfCV, parentAction);
                relatedActions.Add(relatedAction);
            }

            return this.Link(entity, featureActions, actionBies, relatedActions, method);
        }

        public Core.Action Scaffold(ESDATModel esdatModel)
        {
            Core.Action action = new Core.Action();

            action.ActionTypeCV = ActionTypeCVSampleCollection;
            action.BeginDateTime = esdatModel.DateReported;

            return action;
        }

        public Core.Action Scaffold(ChemistryFileData chemistry)
        {
            var entity = new Core.Action();

            entity.ActionTypeCV = ActionTypeCVChemistry;
            entity.BeginDateTime = chemistry.AnalysedDate;

            return entity;
        }

        public Core.Action Link(Core.Action entity, IEnumerable<FeatureAction> featureActions, IEnumerable<ActionBy> actionBies, IEnumerable<RelatedAction> relatedActions, Method method)
        {
            entity.Method = method;
            entity.MethodID = method.MethodID;

            foreach (FeatureAction featureAction in featureActions)
            {
                entity.FeatureActions.Add(featureAction);
            }

            foreach (ActionBy actionBy in actionBies)
            {
                entity.ActionBies.Add(actionBy);
            }

            foreach (RelatedAction relatedAction in relatedActions)
            {
                entity.RelatedActions.Add(relatedAction);
            }

            return entity;
        }
    }
}
