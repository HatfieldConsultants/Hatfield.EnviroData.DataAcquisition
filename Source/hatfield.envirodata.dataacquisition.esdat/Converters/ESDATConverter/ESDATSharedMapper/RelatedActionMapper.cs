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

        public RelatedActionMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public RelatedAction Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);

            return entity;
        }

        public RelatedAction Draft(ESDATModel esdatModel)
        {
            var entity = new RelatedAction();

            entity.ActionID = _action.ActionID;
            entity.RelationshipTypeCV = _relationshipTypeCV;
            entity.RelatedActionID = _action1.ActionID;
            entity.Action = _action;
            entity.Action1 = _action1;

            Validate(entity);

            return entity;
        }

        public override void SetRelationship(Core.Action action, string relationshipTypeCV, Core.Action action1)
        {
            _action = action;
            _action1 = action1;
            _relationshipTypeCV = relationshipTypeCV;
        }
    }
}
