using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MeasurementResultMapperBase : ODM2MapperBase<MeasurementResult>
    {
        public MeasurementResultMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(MeasurementResult entity)
        {
            Validate(entity.CensorCodeCV, new ODM2MapperSourceLocation(this.ToString(), GetVariableName(() => entity.CensorCodeCV)));
            Validate(entity.QualityCodeCV, new ODM2MapperSourceLocation(this.ToString(), GetVariableName(() => entity.QualityCodeCV)));
            Validate(entity.AggregationStatisticCV, new ODM2MapperSourceLocation(this.ToString(), GetVariableName(() => entity.AggregationStatisticCV)));
        }
    }
}
