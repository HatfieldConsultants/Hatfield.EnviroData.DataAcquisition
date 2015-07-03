using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ResultMapperBase : IODM2Mapper<Result>
    {
        public abstract Result Scaffold();
        public abstract Result Map();
    }
}
