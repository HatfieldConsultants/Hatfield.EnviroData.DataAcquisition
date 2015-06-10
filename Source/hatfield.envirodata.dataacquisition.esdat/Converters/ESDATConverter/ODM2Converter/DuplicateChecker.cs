using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DuplicateChecker
    {
        IDbContext _dbContext;

        public DuplicateChecker(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Check<T>(T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            var match = _dbContext.Query<T>().Where(predicate).FirstOrDefault();

            if (match == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return match;
            }
        }
    }
}
