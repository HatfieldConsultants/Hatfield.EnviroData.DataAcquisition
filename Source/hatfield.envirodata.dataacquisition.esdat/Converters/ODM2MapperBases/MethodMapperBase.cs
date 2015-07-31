using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MethodMapperBase : ODM2MapperBase<Method>, IODM2DuplicableMapper<Method>
    {
        public List<Method> BackingStore { get; set; }

        public MethodMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Method entity)
        {
            Validate(entity.MethodTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.MethodTypeCV)));
            Validate(entity.MethodCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.MethodCode)));
            Validate(entity.MethodName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.MethodName)));
        }

        public Method GetDuplicate(WayToHandleNewData wayToHandleNewData, Method entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Method>(
                entity, x =>
                x.MethodName.Equals(entity.MethodName) &&
                x.MethodCode.Equals(entity.MethodCode) &&
                x.MethodTypeCV.Equals(entity.MethodTypeCV),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }
    }
}
