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

        public T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate, WayToHandleNewData wayToHandleNewData) where T : class
        {
            var match = _dbContext.Query<T>().Where(predicate).FirstOrDefault();

            if (match == null)
            {
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
