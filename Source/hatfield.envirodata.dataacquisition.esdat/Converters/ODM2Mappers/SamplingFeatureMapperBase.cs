using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class SamplingFeatureMapperBase : IODM2DuplicableMapper<SamplingFeature>
    {
        public abstract SamplingFeature Scaffold();
        public abstract SamplingFeature Map();

        public SamplingFeature GetDuplicate(ODM2DuplicateChecker duplicateChecker, SamplingFeature entity)
        {
            return duplicateChecker.GetDuplicate<SamplingFeature>(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV)
            );
        }
    }
}
