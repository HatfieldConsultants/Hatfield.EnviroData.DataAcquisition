using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ProcessingLevelMapper : ProcessingLevelMapperBase, IESDATSharedMapper<ProcessingLevel>
    {
        public ProcessingLevelMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public ProcessingLevel Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_duplicateChecker, _wayToHandleNewData, entity);

            return entity;
        }

        public ProcessingLevel Scaffold(ESDATModel esdatModel)
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = _WQDefaultValueProvider.DefaultProcessingLevels;

            return processingLevel;
        }
    }
}
