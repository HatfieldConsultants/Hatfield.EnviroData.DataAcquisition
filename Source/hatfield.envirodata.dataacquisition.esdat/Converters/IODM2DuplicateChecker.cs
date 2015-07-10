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
        T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate, WayToHandleNewData wayToHandleNewData) where T : class;
    }
}
