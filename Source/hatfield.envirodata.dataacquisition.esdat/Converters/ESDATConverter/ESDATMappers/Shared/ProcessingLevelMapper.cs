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
        public ProcessingLevelMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public ProcessingLevel Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public ProcessingLevel Scaffold(ESDATModel esdatModel)
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = _WQDefaultValueProvider.DefaultProcessingLevelCode;

            LogScaffoldingComplete(this);

            return processingLevel;
        }
    }
}
