using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ODM2DuplicateChecker
    {
        IDbContext _dbContext;

        public ODM2DuplicateChecker(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets a matching entity from the database based on the provided entity and predicate
        /// </summary>
        /// <typeparam name="T">ODM2 entity</typeparam>
        /// <param name="entity">The entity to find</param>
        /// <param name="predicate">The equality criteria lambda</param>
        /// <returns>An entity that matches the given criteria</returns>
        /// <exception>The given entity does not exist in the database</exception>
        public T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate) where T : class
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
