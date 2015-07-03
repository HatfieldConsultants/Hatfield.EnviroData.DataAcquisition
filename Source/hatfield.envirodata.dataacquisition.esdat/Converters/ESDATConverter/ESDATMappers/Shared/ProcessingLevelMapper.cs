using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ProcessingLevelMapper : ProcessingLevelMapperBase
    {
        protected ESDATMapperParametersBase _parameters;

        public ProcessingLevelMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override ProcessingLevel Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override ProcessingLevel Scaffold()
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = string.Empty;

            return processingLevel;
        }
    }
}
