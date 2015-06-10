using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ProcessingLevelMapper : ODM2MapperQueryable
    {
        public ProcessingLevelMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public ProcessingLevel Map(Result result)
        {
            var entity = this.Scaffold(result);
            entity = this.GetDbMatch(entity, x =>
                x.ProcessingLevelCode.Equals(entity.ProcessingLevelCode)
            );

            return this.Link(entity, result);
        }

        public ProcessingLevel Scaffold(Result result)
        {
            ProcessingLevel processingLevel = new ProcessingLevel();

            processingLevel.ProcessingLevelCode = string.Empty;

            return processingLevel;
        }

        public ProcessingLevel CheckDuplicate(ProcessingLevel entity)
        {
            return this.GetDbMatch(entity, x =>
                x.ProcessingLevelID.Equals(entity.ProcessingLevelID)
            );
        }

        public ProcessingLevel Link(ProcessingLevel entity, Result result)
        {
            entity.Results.Add(result);

            return entity;
        }
    }
}
