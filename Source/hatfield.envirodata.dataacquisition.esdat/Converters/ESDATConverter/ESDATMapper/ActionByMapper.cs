using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionByMapper : ESDATMapper
    {
        AffiliationMapper _affiliationMapper;

        public ActionByMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _affiliationMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Affiliation)) as AffiliationMapper;
        }

        public ActionBy Map()
        {
            var entity = Scaffold();

            var affiliation = _affiliationMapper.Map(entity);
            _linker.Link(entity, affiliation);

            return entity;
        }

        public ActionBy Scaffold()
        {
            var actionBy = new ActionBy();

            actionBy.BridgeID = 0;
            actionBy.IsActionLead = true;
            actionBy.RoleDescription = null;
            
            return actionBy;
        }
    }
}
