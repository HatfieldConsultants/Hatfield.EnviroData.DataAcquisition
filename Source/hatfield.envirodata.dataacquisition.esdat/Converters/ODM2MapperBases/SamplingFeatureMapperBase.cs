using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class SamplingFeatureMapperBase : ODM2MapperBase<SamplingFeature>, IODM2DuplicableMapper<SamplingFeature>
    {
        public List<SamplingFeature> BackingStore { get; set; }

        public SamplingFeatureMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(SamplingFeature entity)
        {
            Validate(entity.SamplingFeatureTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureTypeCV)));
            Validate(entity.SamplingFeatureCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureCode)));
            Validate(entity.SamplingFeatureName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureName)));
            Validate(entity.SamplingFeatureUUID, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureUUID)));

        }

        public SamplingFeature GetDuplicate(WayToHandleNewData wayToHandleNewData, SamplingFeature entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<SamplingFeature>(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV) &&
                x.SamplingFeatureCode.Equals(entity.SamplingFeatureCode) &&
                x.SamplingFeatureName.Equals(entity.SamplingFeatureName) &&
                x.SamplingFeatureUUID.Equals(entity.SamplingFeatureUUID),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }
    }
}
