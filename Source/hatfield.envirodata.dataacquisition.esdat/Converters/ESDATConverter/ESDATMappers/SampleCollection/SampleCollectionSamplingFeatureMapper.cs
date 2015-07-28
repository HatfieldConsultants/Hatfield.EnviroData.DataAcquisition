using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionSamplingFeatureMapper : SamplingFeatureMapperBase, IESDATSampleCollectionMapper<SamplingFeature>
    {
        public SampleCollectionSamplingFeatureMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public SamplingFeature Draft(ESDATModel esdatModel)
        {
            var entity = new SamplingFeature();

            entity.SamplingFeatureTypeCV = _WQDefaultValueProvider.DefaultSamplingFeatureTypeCVSampleCollection;
            entity.SamplingFeatureCode = _WQDefaultValueProvider.DefaultSamplingFeatureCode;
            entity.SamplingFeatureUUID = new Guid();

            Validate(entity);

            return entity;
        }
    }
}
