using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class VariableConverter : ODM2ActionConverter
    {
        // Shared Constants
        private const string SpeciationCV = "notApplicable";
        private const int NoDataValue = -9999;

        // Sample Collection Constants
        private const string VariableTypeCVSampleCollection = "Sample";

        // Chemistry Constants
        private const string VariableTypeCVChemistry = "Chemistry";

        public VariableConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Variable Convert(Result result, SampleFileData sample)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVSampleCollection;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = string.Empty;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;
            variable.Results.Add(result);

            return variable;
        }

        public Variable Convert(Result result, ChemistryFileData chemistry)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVChemistry;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = chemistry.OriginalChemName;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;
            variable.Results.Add(result);

            return variable;
        }
    }
}
