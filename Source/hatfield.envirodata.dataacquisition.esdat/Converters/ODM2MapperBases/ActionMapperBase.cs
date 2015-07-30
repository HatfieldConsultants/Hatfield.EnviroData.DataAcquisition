using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ActionMapperBase : ODM2MapperBase<Core.Action>
    {
        public ActionMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Core.Action entity)
        {
            Validate(entity.ActionTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.ActionTypeCV)));
            Validate(entity.BeginDateTime, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.BeginDateTime)));
        }
    }
}
