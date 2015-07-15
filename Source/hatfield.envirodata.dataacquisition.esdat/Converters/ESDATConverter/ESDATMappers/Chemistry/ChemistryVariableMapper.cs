using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryVariableMapper : VariableMapperBase, IESDATChemistryMapper<Variable>
    {
        public ChemistryVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Variable Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Variable Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = _WQDefaultValueProvider.DefaultVariableTypeCVChemistry;
            variable.VariableCode = _WQDefaultValueProvider.DefaultVariableCode;
            variable.VariableNameCV = chemistry.OriginalChemName;
            variable.SpeciationCV = _WQDefaultValueProvider.DefaultVariableSpeciationCV;
            variable.NoDataValue = _WQDefaultValueProvider.DefaultVariableNoDataValue;

            return variable;
        }
    }
}
