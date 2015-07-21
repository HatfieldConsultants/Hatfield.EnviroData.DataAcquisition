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
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Method Draft(ESDATModel esdatModel)
        {
            var entity = new Method();

            entity.MethodTypeCV = _WQDefaultValueProvider.DefaultMethodTypeCVSampleCollection;
            entity.MethodCode = string.Empty;
            entity.MethodName = _WQDefaultValueProvider.DefaultMethodTypeCVSampleCollection;

            Validate(entity);

            return entity;
        }
    }
}
