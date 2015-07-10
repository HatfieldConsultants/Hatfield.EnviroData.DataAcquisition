using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class VariableMapperBase : ESDATMapperBase<Variable>, IODM2DuplicableMapper<Variable>
    {
        public VariableMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Variable GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, Variable entity)
        {
            return duplicateChecker.GetDuplicate<Variable>(entity, x =>
                x.VariableTypeCV.Equals(entity.VariableTypeCV),
                wayToHandleNewData
            );
        }
    }
}
