using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class RelatedActionConverter : ODM2ConverterBase
    {
        public RelatedActionConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public RelatedAction Convert(Core.Action action, string relatioshipTypeCV, Core.Action action1)
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
    }
}
