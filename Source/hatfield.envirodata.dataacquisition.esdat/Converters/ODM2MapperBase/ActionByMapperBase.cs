using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ActionByMapperBase : ODM2MapperBase<ActionBy>
    {
        public ActionByMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(ActionBy entity)
        {
            Validate(entity.IsActionLead, new ODM2MapperSourceLocation(this.ToString(), GetVariableName(() => entity.IsActionLead)));
        }
    }
}
