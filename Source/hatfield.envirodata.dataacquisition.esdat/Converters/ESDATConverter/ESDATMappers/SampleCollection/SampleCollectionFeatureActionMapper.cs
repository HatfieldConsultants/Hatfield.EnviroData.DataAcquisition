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
            var entity = Draft(esdatModel);

            return entity;
        }

        public FeatureAction Draft(ESDATModel esdatModel)
        {
            var entity = new FeatureAction();

            Validate(entity);

            return entity;
        }
    }
}
