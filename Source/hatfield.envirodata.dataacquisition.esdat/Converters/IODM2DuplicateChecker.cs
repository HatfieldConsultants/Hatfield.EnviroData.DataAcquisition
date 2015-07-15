using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IODM2DuplicateChecker
    {
        /// <summary>
        /// Finds and returns the given entity from the database or the backing store
        /// </summary>
        /// <typeparam name="T">The entity type</typeparam>
        /// <param name="entity">The entity to match</param>
        /// <param name="predicate">The matching predicate</param>
        /// <param name="wayToHandleNewData">The way to handle when no match found</param>
        /// <param name="backingStore">An additional store to find match</param>
        /// <returns></returns>
        T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate, WayToHandleNewData wayToHandleNewData, List<T> backingStore) where T : class;
    }
}
