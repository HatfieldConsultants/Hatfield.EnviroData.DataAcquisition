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
        public ProcessingLevelMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public ProcessingLevel GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, ProcessingLevel entity)
        {
            return duplicateChecker.GetDuplicate<ProcessingLevel>(entity, x =>
                x.ProcessingLevelCode.Equals(entity.ProcessingLevelCode),
                wayToHandleNewData
            );
        }
    }
}
