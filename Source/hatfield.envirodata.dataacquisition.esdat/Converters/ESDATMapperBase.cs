using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ESDATMapperBase<T> where T : class
    {
        protected ESDATDuplicateChecker _duplicateChecker;
        protected IWQDefaultValueProvider _WQDefaultValueProvider;
        protected WayToHandleNewData _wayToHandleNewData;

        public ESDATMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
        {
            _duplicateChecker = duplicateChecker;
            _WQDefaultValueProvider = WQDefaultValueProvider;
            _wayToHandleNewData = wayToHandleNewData;
        }
    }
}
