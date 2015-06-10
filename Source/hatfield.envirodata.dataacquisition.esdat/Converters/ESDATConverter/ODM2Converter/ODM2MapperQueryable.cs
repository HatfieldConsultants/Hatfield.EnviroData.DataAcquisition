using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ODM2MapperQueryable : ODM2MapperBase
    {
        public ODM2MapperQueryable(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        protected T GetDbMatch<T>(T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            return _duplicateChecker.Check<T>(entity, predicate);
        }
    }
}
