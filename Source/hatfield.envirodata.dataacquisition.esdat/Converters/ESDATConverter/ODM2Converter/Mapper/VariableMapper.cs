using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class VariableMapper : ODM2MapperQueryable
    {
        // Shared Constants
        private const string SpeciationCV = "notApplicable";
        private const int NoDataValue = -9999;

        // Sample Collection Constants
        private const string VariableTypeCVSampleCollection = "Sample";

        // Chemistry Constants
        private const string VariableTypeCVChemistry = "Chemistry";

        public VariableMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Variable Map(SampleFileData sample, Result result)
        {
            var entity = this.Scaffold(sample);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, result);
        }

        public Variable Map(ChemistryFileData chemistry, Result result)
        {
            var entity = this.Scaffold(chemistry);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, result);
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

        public Variable CheckDuplicate(Variable entity)
        {
            return this.GetDbMatch(entity, x =>
                x.VariableTypeCV.Equals(entity.VariableTypeCV)
            );
        }

        public Variable Link(Variable entity, Result result)
        {
            entity.Results.Add(result);

            return entity;
        }
    }
}
