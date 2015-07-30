using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IODM2DuplicableMapper<T> where T : class
    {
        List<T> BackingStore { get; set; }

        T GetDuplicate(WayToHandleNewData wayToHandleNewData, T entity);
    }
}
