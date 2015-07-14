using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ProcessingLevelMapperBase : ESDATMapperBase<ProcessingLevel>, IODM2DuplicableMapper<ProcessingLevel>
    {
        List<ProcessingLevel> _backingStore;

        public ProcessingLevelMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public void SetBackingStore(List<ProcessingLevel> backingStore)
        {
            _backingStore = backingStore;
        }

        public ProcessingLevel GetDuplicate(WayToHandleNewData wayToHandleNewData, ProcessingLevel entity)
        {
            return _duplicateChecker.GetDuplicate<ProcessingLevel>(entity, x =>
                x.ProcessingLevelCode.Equals(entity.ProcessingLevelCode),
                wayToHandleNewData,
                _backingStore
            );
        }
    }
}
