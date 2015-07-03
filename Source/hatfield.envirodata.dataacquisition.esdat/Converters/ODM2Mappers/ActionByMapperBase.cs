using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ActionByMapperBase : IODM2Mapper<ActionBy>
    {
        public abstract ActionBy Scaffold();
        public abstract ActionBy Map();
    }
}
