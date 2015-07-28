using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{                
    public abstract class ResultMapperBase : ODM2MapperBase<Result>
    {
        public ResultMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Result entity)
        {
            Validate(entity.ResultTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.ResultTypeCV)));
            Validate(entity.ResultDateTime, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.ResultDateTime)));
            Validate(entity.SampledMediumCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SampledMediumCV)));
            Validate(entity.ValueCount, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.ValueCount)));
        }
    }
}
