using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ProcessingLevelMapperBase : IODM2DuplicableMapper<ProcessingLevel>
    {
        public abstract ProcessingLevel Scaffold();
        public abstract ProcessingLevel Map();

        public ProcessingLevel GetDuplicate(ODM2DuplicateChecker duplicateChecker, ProcessingLevel entity)
        {
            return duplicateChecker.GetDuplicate<ProcessingLevel>(entity, x =>
                x.ProcessingLevelCode.Equals(entity.ProcessingLevelCode)
            );
        }
    }
}
