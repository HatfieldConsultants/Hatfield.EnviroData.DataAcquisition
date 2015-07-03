using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionByMapper : ActionByMapperBase
    {
        protected ESDATMapperParametersBase _parameters;

        public ActionByMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override ActionBy Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override ActionBy Scaffold()
        {
            var entity = new ActionBy();

            entity.BridgeID = 0;
            entity.IsActionLead = true;
            entity.RoleDescription = null;

            return entity;
        }
    }
}
