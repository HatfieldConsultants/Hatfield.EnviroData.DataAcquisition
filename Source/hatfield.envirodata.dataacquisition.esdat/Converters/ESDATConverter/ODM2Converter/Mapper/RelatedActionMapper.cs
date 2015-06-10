using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class RelatedActionMapper : ODM2MapperQueryable
    {
        public RelatedActionMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public RelatedAction Map(Core.Action action, string relatioshipTypeCV, Core.Action action1)
        {
            var relatedAction = this.Scaffold(action, relatioshipTypeCV, action1);

            return relatedAction;
        }

        public RelatedAction Scaffold(Core.Action action, string relatioshipTypeCV, Core.Action action1)
        {
            RelatedAction relatedAction = new RelatedAction();

            relatedAction.RelationID = 0;
            relatedAction.ActionID = action.ActionID;
            relatedAction.RelationshipTypeCV = relatioshipTypeCV;
            relatedAction.RelatedActionID = action1.ActionID;
            relatedAction.Action = action;
            relatedAction.Action1 = action1;

            return relatedAction;
        }

        public RelatedAction CheckDuplicate(RelatedAction entity)
        {
            return this.GetDbMatch(entity, x =>
                x.RelatedActionID.Equals(entity.RelatedActionID)
            );
        }
    }
}
