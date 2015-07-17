using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ActionByMapper : ActionByMapperBase, IESDATSharedMapper<ActionBy>
    {
        public ActionByMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public ActionBy Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            LogMappingComplete(this);

            return entity;
        }

        public ActionBy Scaffold(ESDATModel esdatModel)
        {
            var entity = new ActionBy();

            entity.BridgeID = 0;
            entity.IsActionLead = true;
            entity.RoleDescription = null;

            LogScaffoldingComplete(this);

            return entity;
        }
    }
}
