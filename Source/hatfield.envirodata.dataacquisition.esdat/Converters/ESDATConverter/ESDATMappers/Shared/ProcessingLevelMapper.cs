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
        public ProcessingLevelMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public ProcessingLevel Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public ProcessingLevel Draft(ESDATModel esdatModel)
        {
            var entity = new ProcessingLevel();

            entity.ProcessingLevelCode = _WQDefaultValueProvider.DefaultProcessingLevelCode;

            Validate(entity);

            return entity;
        }
    }
}
