using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionByMapper : ODM2MapperBase
    {
        public ActionByMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public ActionBy Map(Core.Action action, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(action);

            var affiliationMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Affiliation)) as AffiliationMapper;
            var affiliation = affiliationMapper.Map(entity, factory);

            return this.Link(entity, affiliation);
        }

        public ActionBy Scaffold(Core.Action action)
        {
            var actionBy = new ActionBy();

            actionBy.BridgeID = 0;
            actionBy.ActionID = action.ActionID;
            actionBy.IsActionLead = true;
            actionBy.RoleDescription = null;
            actionBy.Action = action;
            
            return actionBy;
        }

        public ActionBy Link(ActionBy entity, Affiliation affiliation)
        {
            entity.Affiliation = affiliation;
            entity.AffiliationID = affiliation.AffiliationID;

            return entity;
        }
    }
}
