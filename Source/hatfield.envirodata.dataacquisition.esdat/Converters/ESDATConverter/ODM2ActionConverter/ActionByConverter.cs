using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class ActionByConverter : ODM2ActionConverter
    {
        public ActionByConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public ActionBy Convert(Core.Action action, AffiliationConverter affiliationConverter, PersonConverter personConverter)
        {
            ActionBy actionBy = new ActionBy();

            var affiliation = affiliationConverter.Convert(actionBy, personConverter);

            actionBy.BridgeID = 0;
            actionBy.ActionID = action.ActionID;
            actionBy.AffiliationID = affiliation.AffiliationID;
            actionBy.IsActionLead = true;
            actionBy.RoleDescription = null;
            actionBy.Action = action;
            actionBy.Affiliation = affiliation;

            return actionBy;
        }
    }
}
