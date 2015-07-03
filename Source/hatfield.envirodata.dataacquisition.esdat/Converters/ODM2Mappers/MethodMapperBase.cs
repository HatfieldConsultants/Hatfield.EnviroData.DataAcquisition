using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class MethodMapperBase : IODM2DuplicableMapper<Method>
    {
        public abstract Method Scaffold();
        public abstract Method Map();

        public Method GetDuplicate(ODM2DuplicateChecker duplicateChecker, Method entity)
        {
            return duplicateChecker.GetDuplicate<Method>(entity, x =>
                x.MethodTypeCV.Equals(entity.MethodTypeCV)
            );
        }
    }
}
