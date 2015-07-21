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
        List<Variable> _backingStore;

        public VariableMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Variable> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Variable entity)
        {
            Validate(entity.VariableTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.VariableTypeCV)));
            Validate(entity.VariableCode, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.VariableCode)));
            Validate(entity.VariableNameCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.VariableNameCV)));
            Validate(entity.SpeciationCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.SpeciationCV)));
            Validate(entity.NoDataValue, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.NoDataValue)));
        }

        public Variable GetDuplicate(WayToHandleNewData wayToHandleNewData, Variable entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Variable>(entity, x =>
                x.VariableTypeCV.Equals(entity.VariableTypeCV),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
