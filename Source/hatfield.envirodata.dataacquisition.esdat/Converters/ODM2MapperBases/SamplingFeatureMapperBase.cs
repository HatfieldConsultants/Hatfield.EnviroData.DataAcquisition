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
        List<SamplingFeature> _backingStore;

        public SamplingFeatureMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<SamplingFeature> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(SamplingFeature entity)
        {
            Validate(entity.SamplingFeatureTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureTypeCV)));
            Validate(entity.SamplingFeatureCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureCode)));
            Validate(entity.SamplingFeatureUUID, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.SamplingFeatureUUID)));
        }

        public SamplingFeature GetDuplicate(WayToHandleNewData wayToHandleNewData, SamplingFeature entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<SamplingFeature>(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
