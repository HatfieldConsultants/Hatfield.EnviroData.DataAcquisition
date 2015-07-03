using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class FeatureActionMapperBase : IODM2Mapper<FeatureAction>
    {
        public abstract FeatureAction Scaffold();
        public abstract FeatureAction Map();
    }
}
