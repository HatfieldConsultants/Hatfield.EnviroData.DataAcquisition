using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class DatasetMapperBase : IODM2Mapper<Dataset>
    {
        public abstract Dataset Scaffold();
        public abstract Dataset Map();
    }
}
