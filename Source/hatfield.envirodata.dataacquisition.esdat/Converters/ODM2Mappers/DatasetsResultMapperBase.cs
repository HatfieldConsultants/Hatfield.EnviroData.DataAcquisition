using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class DatasetsResultMapperBase : IODM2Mapper<DatasetsResult>
    {
        public abstract DatasetsResult Scaffold();
        public abstract DatasetsResult Map();
    }
}
