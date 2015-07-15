using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{                
    public abstract class SamplingFeatureMapperBase : ESDATMapperBase<SamplingFeature>, IODM2DuplicableMapper<SamplingFeature>
    {
        List<SamplingFeature> _backingStore;

        public SamplingFeatureMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public void SetBackingStore(List<SamplingFeature> backingStore)
        {
            _backingStore = backingStore;
        }

        public SamplingFeature GetDuplicate(WayToHandleNewData wayToHandleNewData, SamplingFeature entity)
        {
            return _duplicateChecker.GetDuplicate<SamplingFeature>(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV),
                wayToHandleNewData,
                _backingStore
            );
        }
    }
}
