using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryVariableMapper : VariableMapperBase
    {
        // Shared Constants
        private const string SpeciationCV = "Unknown";
        private const int NoDataValue = -9999;

        // Chemistry Constants
        private const string VariableTypeCVChemistry = "Chemistry";

        protected ESDATChemistryParameters _parameters;

        public ChemistryVariableMapper(ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
        }

        public override Variable Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Variable Scaffold()
        {
            Variable variable = new Variable();

            var chemistry = _parameters.ChemistryFileData;

            variable.VariableTypeCV = VariableTypeCVChemistry;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = chemistry.OriginalChemName;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;

            return variable;
        }
    }
}
