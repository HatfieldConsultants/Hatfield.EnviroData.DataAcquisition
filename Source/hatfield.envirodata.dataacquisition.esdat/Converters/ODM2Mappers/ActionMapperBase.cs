using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ActionMapperBase : IODM2Mapper<Core.Action>
    {
        public abstract Core.Action Scaffold();
        public abstract Core.Action Map();
    }
}
