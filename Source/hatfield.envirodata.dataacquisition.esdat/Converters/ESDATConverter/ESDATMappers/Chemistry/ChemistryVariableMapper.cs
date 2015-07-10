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
        // Shared Constants
        private const string SpeciationCV = "Unknown";
        private const int NoDataValue = -9999;

        // Chemistry Constants
        private const string VariableTypeCVChemistry = "Chemistry";

        public ChemistryVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Variable Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_duplicateChecker, _wayToHandleNewData, entity);

            return entity;
        }

        public Variable Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVChemistry;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = chemistry.OriginalChemName;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;

            return variable;
        }
    }
}
