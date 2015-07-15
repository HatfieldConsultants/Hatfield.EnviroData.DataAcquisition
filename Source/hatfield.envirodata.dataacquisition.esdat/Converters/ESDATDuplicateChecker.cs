using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATDuplicateChecker : IODM2DuplicateChecker
    {
        IDbContext _dbContext;

        public ESDATDuplicateChecker(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate, WayToHandleNewData wayToHandleNewData, List<T> backingStore) where T : class
        {
            // Try to match from the database
            var match = _dbContext.Query<T>().FirstOrDefault(predicate);

            // Try to match from backing store
            if (match == null)
            {
                var store = backingStore.AsQueryable<T>();
                match = store.FirstOrDefault(predicate);
            }

            // Handle if no match anywhere
            if (match == null)
            {
                // Add data to backing store
                backingStore.Add(entity);

                switch (wayToHandleNewData)
                {
                    case WayToHandleNewData.CreateInstanceForNewData:
                        {
                            return entity;
                        }

                    case WayToHandleNewData.SetNewDataToBeNull:
                        {
                            return null;
                        }

                    case WayToHandleNewData.ThrowExceptionForNewData:
                        {
                            throw new KeyNotFoundException();
                        }

                    case WayToHandleNewData.WarningForNewData:
                        {
                            Console.WriteLine("Warning: New entry " + entity + " created");
                            return entity;
                        }

                    default:
                        {
                            throw new ArgumentNullException();
                        }
                }
            }
            else
            {
                return match;
            }
        }
    }
}
