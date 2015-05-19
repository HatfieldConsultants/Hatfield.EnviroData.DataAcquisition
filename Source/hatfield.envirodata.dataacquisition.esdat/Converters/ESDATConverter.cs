using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATConverter
    {
        private IDbContext _dbContext;

        public ESDATConverter(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Converts an ESDATModel to a Core.Action
        /// See https://github.com/HatfieldConsultants/Hatfield.EnviroData.Core/wiki/Loading-ESDAT-data-into-ODM2 for mapping details
        /// <returns>An EnviroData.Core.Action based on the current ESDATModel</returns>
        public Core.Action ConvertToODMAction(ESDATModel dataModel)
        {
            Core.Action action = new Core.Action();
            action.ActionID = 0;
            action.ActionTypeCV = "specimenCollection";
            action.BeginDateTime = dataModel.SampleFileData.SampledDateTime.Value;
            action.EndDateTime = null;
            action.EndDateTimeUTCOffset = null;
            action.ActionDescription = null;
            action.ActionFileLink = null;

            ActionAnnotation actionAnnotation = new ActionAnnotation();
            Annotation annotation = new Annotation();
            annotation.AnnotationID = 0;
            annotation.AnnotationTypeCV = "resultAnnotation";
            annotation.AnnotationCode = null;
            annotation.AnnotationTypeCV = null;
            annotation.AnnotationDateTime = null;
            annotation.AnnotationUTCOffset = null;
            annotation.AnnotatorID = null;
            annotation.CitationID = null;
            action.ActionAnnotations.Add(actionAnnotation);

            ActionBy actionBy = new ActionBy();
            actionBy.BridgeID = 0;
            actionBy.ActionID = 0;
            actionBy.AffiliationID = 0;
            actionBy.IsActionLead = true;
            actionBy.RoleDescription = null;
            action.ActionBies.Add(actionBy);

            ActionDirective actionDirective = new ActionDirective();
            action.ActionDirectives.Add(actionDirective);

            ActionExtensionPropertyValue actionExtensionPropertyValue = new ActionExtensionPropertyValue();
            action.ActionExtensionPropertyValues.Add(actionExtensionPropertyValue);

            EquipmentUsed equipmentUsed = new EquipmentUsed();
            action.EquipmentUseds.Add(equipmentUsed);

            FeatureAction featureAction = new FeatureAction();
            featureAction.FeatureActionID = 0;
            featureAction.SamplingFeature = null;
            featureAction.ActionID = action.ActionID;
            action.FeatureActions.Add(featureAction);

            RelatedAction relatedAction = new RelatedAction();
            relatedAction.RelationID = 0;
            relatedAction.ActionID = action.ActionID;
            relatedAction.RelationshipTypeCV = "isParentOf";
            relatedAction.RelatedActionID = action.ActionID;
            action.RelatedActions.Add(relatedAction);

            RelatedAction relatedAction1 = new RelatedAction();
            relatedAction1.RelationID = 0;
            relatedAction1.ActionID = action.ActionID;
            relatedAction1.RelationshipTypeCV = "isParentOf";
            relatedAction1.RelatedActionID = action.ActionID;
            action.RelatedActions1.Add(relatedAction1);

            Simulation simulation = new Simulation();
            action.Simulations.Add(simulation);

            return action;
        }
    }
}
