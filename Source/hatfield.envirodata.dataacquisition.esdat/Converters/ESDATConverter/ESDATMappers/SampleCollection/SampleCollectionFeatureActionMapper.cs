using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionFeatureActionMapper : FeatureActionMapperBase, IESDATSampleCollectionMapper<FeatureAction>
    {
        public SampleCollectionFeatureActionMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public FeatureAction Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            return entity;
        }

        public FeatureAction Scaffold(ESDATModel esdatModel)
        {
            return new FeatureAction();
        }
    }
}
