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

        public MethodMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public void SetBackingStore(List<Method> backingStore)
        {
            _backingStore = backingStore;
        }

        public Method GetDuplicate(WayToHandleNewData wayToHandleNewData, Method entity)
        {
            return _duplicateChecker.GetDuplicate<Method>(entity, x =>
                x.MethodTypeCV.Equals(entity.MethodTypeCV),
                wayToHandleNewData,
                _backingStore
            );
        }
    }
}
