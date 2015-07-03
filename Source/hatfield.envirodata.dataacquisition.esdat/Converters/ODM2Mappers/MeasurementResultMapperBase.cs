using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MeasurementResultMapperBase : IODM2Mapper<MeasurementResult>
    {
        public abstract MeasurementResult Scaffold();
        public abstract MeasurementResult Map();
    }
}
