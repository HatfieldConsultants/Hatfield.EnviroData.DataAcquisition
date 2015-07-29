using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ODM2DuplicateChecker : IODM2DuplicateChecker
    {
        IDbContext _dbContext;

        public ODM2DuplicateChecker(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate, WayToHandleNewData wayToHandleNewData, List<T> backingStore) where T : class
        {
            // Try the database
            var match = _dbContext.Query<T>().FirstOrDefault(predicate);
            if (match != null)
            {
                Console.WriteLine(this + ": Match found in database.");
            }
            else
            {
                Console.WriteLine(this + ": Match not found in database.");
            }

            // Try the backing store
            if (match == null)
            {
                match = backingStore.AsQueryable().FirstOrDefault(predicate);

                string message;

                if (match != null)
                {
                    message = String.Format(this + ": Match found in backing store.");
                }
                else
                {
                    message = String.Format(this + ": Match not found in backing store.");
                }

                Console.WriteLine(message);
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
                            Console.WriteLine(this + ": New instance created.");

                            return entity;
                        }

                    case WayToHandleNewData.SetNewDataToBeNull:
                        {
                            Console.WriteLine(this + ": New data set to null.");

                            return null;
                        }

                    case WayToHandleNewData.ThrowExceptionForNewData:
                        {
                            Console.WriteLine(this + ": Exception will be thrown.");

                            throw new KeyNotFoundException();
                        }

                    case WayToHandleNewData.WarningForNewData:
                        {
                            Console.WriteLine(this + ": Warning - New entry " + entity + " created");

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
