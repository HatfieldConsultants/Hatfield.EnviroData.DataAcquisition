using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionMethodMapper : MethodMapperBase, IESDATSampleCollectionMapper<Method>
    {
        public SampleCollectionMethodMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Method Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public Method Scaffold(ESDATModel esdatModel)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = _WQDefaultValueProvider.DefaultMethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = _WQDefaultValueProvider.DefaultMethodTypeCVSampleCollection;

            LogScaffoldingComplete(this);

            return method;
        }
    }
}
