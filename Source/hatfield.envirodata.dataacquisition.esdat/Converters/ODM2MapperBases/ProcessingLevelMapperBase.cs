using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ProcessingLevelMapperBase : ODM2MapperBase<ProcessingLevel>, IODM2DuplicableMapper<ProcessingLevel>
    {
        public List<ProcessingLevel> BackingStore { get; set; }

        public ProcessingLevelMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(ProcessingLevel entity)
        {
            Validate(entity.ProcessingLevelCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.ProcessingLevelCode)));
        }

        public ProcessingLevel GetDuplicate(WayToHandleNewData wayToHandleNewData, ProcessingLevel entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<ProcessingLevel>(entity, x =>
                x.ProcessingLevelCode.Equals(entity.ProcessingLevelCode),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }
    }
}
