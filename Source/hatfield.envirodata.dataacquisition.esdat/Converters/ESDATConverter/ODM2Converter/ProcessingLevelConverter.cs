using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ProcessingLevelConverter : ODM2ConverterBase
    {
        public ProcessingLevelConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public ProcessingLevel Convert(Result result)
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = string.Empty;
            processingLevel.Results.Add(result);

            return processingLevel;
        }
    }
}
