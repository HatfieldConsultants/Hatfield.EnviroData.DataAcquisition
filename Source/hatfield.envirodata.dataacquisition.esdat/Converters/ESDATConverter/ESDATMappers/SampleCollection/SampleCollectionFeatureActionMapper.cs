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
        public SampleCollectionFeatureActionMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public FeatureAction Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            LogMappingComplete(this);

            return entity;
        }

        public FeatureAction Scaffold(ESDATModel esdatModel)
        {
            LogScaffoldingComplete(this);

            return new FeatureAction();
        }
    }
}
