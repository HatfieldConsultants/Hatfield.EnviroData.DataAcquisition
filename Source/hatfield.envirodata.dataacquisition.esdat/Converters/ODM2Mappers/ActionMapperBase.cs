using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ActionMapperBase : ESDATMapperBase<Core.Action>
    {
        public ActionMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Core.Action entity)
        {
            Validate(entity.ActionTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.ActionTypeCV)));
            Validate(entity.BeginDateTime, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.BeginDateTime)));
        }
    }
}
