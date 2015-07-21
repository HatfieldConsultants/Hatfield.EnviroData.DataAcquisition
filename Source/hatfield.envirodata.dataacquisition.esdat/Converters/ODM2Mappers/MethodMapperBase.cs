using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MethodMapperBase : ESDATMapperBase<Method>, IODM2DuplicableMapper<Method>
    {
        List<Method> _backingStore;

        public MethodMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Method> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Method entity)
        {
            Validate(entity.MethodTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.MethodTypeCV)));
            Validate(entity.MethodCode, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.MethodCode)));
            Validate(entity.MethodName, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.MethodName)));
        }

        public Method GetDuplicate(WayToHandleNewData wayToHandleNewData, Method entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Method>(entity, x =>
                x.MethodTypeCV.Equals(entity.MethodTypeCV),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
