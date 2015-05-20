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
        /// See https://goo.gl/wF6aD1 for Action class source code
        /// See https://goo.gl/AiVfq4 for mapping details
        /// <returns>An EnviroData.Core.Action based on the current ESDATModel</returns>
        public Core.Action ConvertToODMAction(ESDATModel dataModel)
        {
            // See Actions mapping: https://goo.gl/ckWn22
            Core.Action action = new Core.Action();
            action.ActionID = 0;
            action.EndDateTime = null;
            action.EndDateTimeUTCOffset = null;
            action.ActionDescription = null;
            action.ActionFileLink = null;

            // See Annotations mapping: https://goo.gl/qISZ51
            ActionAnnotation actionAnnotation = new ActionAnnotation();
            Annotation annotation = new Annotation();
            annotation.AnnotationID = 0;
            annotation.AnnotationTypeCV = "resultAnnotation";
            annotation.AnnotationCode = null;
            annotation.AnnotationDateTime = null;
            annotation.AnnotationUTCOffset = null;
            annotation.AnnotatorID = null;
            annotation.CitationID = null;
            action.ActionAnnotations.Add(actionAnnotation);

            // See ActionBy mapping: https://goo.gl/1rV1XN
            ActionBy actionBy = new ActionBy();
            actionBy.ActionID = action.ActionID;
            actionBy.IsActionLead = true;
            actionBy.RoleDescription = null;
            action.ActionBies.Add(actionBy);

            ActionDirective actionDirective = new ActionDirective();
            action.ActionDirectives.Add(actionDirective);

            ActionExtensionPropertyValue actionExtensionPropertyValue = new ActionExtensionPropertyValue();
            action.ActionExtensionPropertyValues.Add(actionExtensionPropertyValue);

            // See Methods mapping: https://goo.gl/6mDG63
            Method method = new Method();
            method.MethodID = 0;
            method.MethodDescription = null;
            method.MethodLink = null;
            action.Method = method;

            CalibrationAction calibrationAction = new CalibrationAction();

            EquipmentUsed equipmentUsed = new EquipmentUsed();
            action.EquipmentUseds.Add(equipmentUsed);

            FeatureAction featureAction = new FeatureAction();
            featureAction.FeatureActionID = 0;
            featureAction.ActionID = action.ActionID;
            action.FeatureActions.Add(featureAction);

            MaintenanceAction maintenanceAction = new MaintenanceAction();

            RelatedAction relatedAction = new RelatedAction();
            relatedAction.RelationID = 0;
            relatedAction.ActionID = action.ActionID;
            action.RelatedActions.Add(relatedAction);

            RelatedAction relatedAction1 = new RelatedAction();
            relatedAction1.RelationID = 0;
            relatedAction1.ActionID = action.ActionID;
            action.RelatedActions1.Add(relatedAction1);

            Simulation simulation = new Simulation();
            action.Simulations.Add(simulation);

            return action;
        }
    }
}
