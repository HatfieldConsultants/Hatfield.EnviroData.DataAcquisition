using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class UnitMapperBase : ODM2MapperBase<Unit>, IODM2DuplicableMapper<Unit>
    {
        public List<Unit> BackingStore { get; set; }

        public UnitMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Unit entity)
        {
            Validate(entity.UnitsTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.UnitsTypeCV)));
            Validate(entity.UnitsAbbreviation, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.UnitsAbbreviation)));
            Validate(entity.UnitsName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.UnitsName)));
        }

        public Unit GetDuplicate(WayToHandleNewData wayToHandleNewData, Unit entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Unit>(entity, x =>
                x.UnitsTypeCV.Equals(entity.UnitsTypeCV) &&
                x.UnitsAbbreviation.Equals(entity.UnitsAbbreviation) &&
                x.UnitsName.Equals(entity.UnitsName),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }

        public string AbbereviateUnit(string name)
        {
            const int unitAbbrevLength = 2;

            return name.Length > unitAbbrevLength ? name.Substring(0, unitAbbrevLength) : name;
        }
    }
}
