using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class RelatedActionMapper : RelatedActionMapperBase
    {
        private Core.Action _action;
        private Core.Action _action1;
        private string _relationshipTypeCV;

        protected ESDATMapperParametersBase _parameters;

        public RelatedActionMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override RelatedAction Map()
        {
            if (ParamsAreNull())
            {
                throw new ArgumentNullException("Please set relationship (parameters).");
            }

            var relatedAction = Scaffold();

            return relatedAction;
        }

        public override RelatedAction Scaffold()
        {
            RelatedAction relatedAction = new RelatedAction();

            relatedAction.RelationID = 0;
            relatedAction.ActionID = _action.ActionID;
            relatedAction.RelationshipTypeCV = _relationshipTypeCV;
            relatedAction.RelatedActionID = _action1.ActionID;
            relatedAction.Action = _action;
            relatedAction.Action1 = _action1;

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
                return true;
            }

            if (_action1 == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(_relationshipTypeCV))
            {
                return true;
            }

            return false;
        }
    }
}
