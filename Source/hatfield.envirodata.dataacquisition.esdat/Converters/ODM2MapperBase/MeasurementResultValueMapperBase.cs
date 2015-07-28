using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MeasurementResultValueMapperBase : ESDATMapperBase<MeasurementResultValue>
    {
        public MeasurementResultValueMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(MeasurementResultValue entity)
        {
            Validate(entity.DataValue, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DataValue)));
            Validate(entity.ValueDateTime, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.ValueDateTime)));
        }
    }
}
