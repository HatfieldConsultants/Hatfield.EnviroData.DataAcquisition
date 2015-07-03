using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MeasurementResultValueMapperBase : IODM2Mapper<MeasurementResultValue>
    {
        public abstract MeasurementResultValue Scaffold();
        public abstract MeasurementResultValue Map();
    }
}
