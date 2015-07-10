using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class UnitMapperBase : ESDATMapperBase<Unit>, IODM2DuplicableMapper<Unit>
    {
        public UnitMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Unit GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, Unit entity)
        {
            return duplicateChecker.GetDuplicate<Unit>(entity, x =>
                x.UnitsTypeCV.Equals(entity.UnitsTypeCV) &&
                x.UnitsAbbreviation.Equals(entity.UnitsAbbreviation) &&
                x.UnitsName.Equals(entity.UnitsName),
                wayToHandleNewData
            );
        }

        protected string AbbereviateUnit(string name)
        {
            const int unitAbbrevLength = 2;

            return name.Length > unitAbbrevLength ? name.Substring(0, unitAbbrevLength) : name;
        }
    }
}
