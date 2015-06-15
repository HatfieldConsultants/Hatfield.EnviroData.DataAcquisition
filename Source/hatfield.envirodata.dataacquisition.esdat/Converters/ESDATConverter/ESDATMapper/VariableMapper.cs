using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class VariableMapper : ESDATMapper
    {
        // Shared Constants
        private const string SpeciationCV = "notApplicable";
        private const int NoDataValue = -9999;

        // Sample Collection Constants
        private const string VariableTypeCVSampleCollection = "Sample";

        // Chemistry Constants
        private const string VariableTypeCVChemistry = "Chemistry";

        public VariableMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public Variable Map(SampleFileData sample)
        {
            var entity = Scaffold(sample);
            entity = GetDuplicate(entity);

            return entity;
        }

        public Variable Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);
            entity = GetDuplicate(entity);

            return entity;
        }

        public Variable Scaffold(SampleFileData sample)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVSampleCollection;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = string.Empty;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;

            return variable;
        }

        public Variable Scaffold(ChemistryFileData chemistry)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVChemistry;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = chemistry.OriginalChemName;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;

            return variable;
        }

        public Variable GetDuplicate(Variable entity)
        {
            return GetDuplicate(entity, x =>
                x.VariableTypeCV.Equals(entity.VariableTypeCV)
            );
        }
    }
}
