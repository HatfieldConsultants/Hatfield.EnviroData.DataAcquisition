using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class UnitMapperBase : IODM2DuplicableMapper<Unit>
    {
        public abstract Unit Scaffold();
        public abstract Unit Map();

        public Unit GetDuplicate(ODM2DuplicateChecker duplicateChecker, Unit entity)
        {
            return duplicateChecker.GetDuplicate<Unit>(entity, x =>
                x.UnitsTypeCV.Equals(entity.UnitsTypeCV) &&
                x.UnitsAbbreviation.Equals(entity.UnitsAbbreviation) &&
                x.UnitsName.Equals(entity.UnitsName)
            );
        }

        protected string AbbereviateUnit(string name)
        {
            const int unitAbbrevLength = 2;

            return name.Length > unitAbbrevLength ? name.Substring(0, unitAbbrevLength) : name;
        }
    }
}
