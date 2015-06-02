using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionByConverter : ODM2ConverterBase
    {
        public ActionByConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public ActionBy Convert(Core.Action action, IESDATDataConverterFactory converterFactory)
        {
            ActionBy actionBy = new ActionBy();

            var affiliationConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Affiliation)) as AffiliationConverter;
            var affiliation = affiliationConverter.Convert(actionBy, converterFactory);

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
