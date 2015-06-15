using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ProcessingLevelMapper : ESDATMapper
    {
        public ProcessingLevelMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public ProcessingLevel Map(Result result)
        {
            var entity = Scaffold(result);
            entity = GetDuplicate(entity);

            return entity;
        }

        public ProcessingLevel Scaffold(Result result)
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = string.Empty;

            return processingLevel;
        }

        public ProcessingLevel GetDuplicate(ProcessingLevel entity)
        {
            return GetDuplicate(entity, x =>
                x.ProcessingLevelID.Equals(entity.ProcessingLevelID)
            );
        }
    }
}
