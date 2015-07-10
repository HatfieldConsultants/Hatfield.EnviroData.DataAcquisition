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
        public SamplingFeatureMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public SamplingFeature GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, SamplingFeature entity)
        {
            return duplicateChecker.GetDuplicate<SamplingFeature>(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV),
                wayToHandleNewData
            );
        }
    }
}
