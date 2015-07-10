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
        // Sample Collection Constants
        private const string MethodTypeCVSampleCollection = "Specimen collection";
        private const string MethodNameSampleCollection = "Specimen collection";

        public SampleCollectionMethodMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Method Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_duplicateChecker, _wayToHandleNewData, entity);

            return entity;
        }

        public Method Scaffold(ESDATModel esdatModel)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            return method;
        }
    }
}
