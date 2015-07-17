using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class RelatedActionMapper : RelatedActionMapperBase, IESDATSharedMapper<RelatedAction>
    {
        private Core.Action _action;
        private Core.Action _action1;
        private string _relationshipTypeCV;

        public RelatedActionMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public RelatedAction Map(ESDATModel esdatModel)
        {
            if (ParamsAreNull())
            {
                throw new ArgumentNullException("Please set relationship (parameters).");
            }

            var relatedAction = Scaffold(esdatModel);

            LogMappingComplete(this);

            return relatedAction;
        }

        public RelatedAction Scaffold(ESDATModel esdatModel)
        {
            RelatedAction relatedAction = new RelatedAction();

            relatedAction.RelationID = 0;
            relatedAction.ActionID = _action.ActionID;
            relatedAction.RelationshipTypeCV = _relationshipTypeCV;
            relatedAction.RelatedActionID = _action1.ActionID;
            relatedAction.Action = _action;
            relatedAction.Action1 = _action1;

            LogScaffoldingComplete(this);

            return relatedAction;
        }

        public override void SetRelationship(Core.Action action, string relationshipTypeCV, Core.Action action1)
        {
            _action = action;
            _action1 = action1;
            _relationshipTypeCV = relationshipTypeCV;
        }

        private bool ParamsAreNull()
        {
            if (_action == null)
            {
                var location = new MapperSourceLocation(this.ToString(), "_action");
                string message = "Value can not be null.";
                LogMappingError(location, message);

                return true;
            }

            if (_action1 == null)
            {
                var location = new MapperSourceLocation(this.ToString(), "_action1");
                string message = "Value can not be null.";
                LogMappingError(location, message);

                return true;
            }

            if (string.IsNullOrEmpty(_relationshipTypeCV))
            {
                var location = new MapperSourceLocation(this.ToString(), "_relationshipTypeCV");
                string message = "Value can not be null.";
                LogMappingError(location, message);

                return true;
            }

            return false;
        }
    }
}
