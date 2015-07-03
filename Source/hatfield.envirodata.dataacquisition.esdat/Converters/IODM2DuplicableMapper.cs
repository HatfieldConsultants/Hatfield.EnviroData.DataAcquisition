using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IODM2DuplicableMapper<T> : IODM2Mapper<T> where T : class
    {
        T GetDuplicate(ODM2DuplicateChecker duplicateChecker, T entity);
    }
}
