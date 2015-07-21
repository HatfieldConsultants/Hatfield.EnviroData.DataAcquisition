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
            var entity = Draft(esdatModel);

            return entity;
        }

        public ActionBy Draft(ESDATModel esdatModel)
        {
            var entity = new ActionBy();

            entity.IsActionLead = true;

            Validate(entity);

            return entity;
        }
    }
}
