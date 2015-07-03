using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class VariableMapperBase : IODM2DuplicableMapper<Variable>
    {
        public abstract Variable Scaffold();
        public abstract Variable Map();

        public Variable GetDuplicate(ODM2DuplicateChecker duplicateChecker, Variable entity)
        {
            return duplicateChecker.GetDuplicate<Variable>(entity, x =>
                x.VariableTypeCV.Equals(entity.VariableTypeCV)
            );
        }
    }
}
