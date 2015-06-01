using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToActionBy : ESDATConverterToODMAction
    {
        public ESDATConverterToActionBy(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public ActionBy Convert(Core.Action action, ESDATConverterToAffiliation affiliationConverter, ESDATConverterToPerson personConverter)
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
