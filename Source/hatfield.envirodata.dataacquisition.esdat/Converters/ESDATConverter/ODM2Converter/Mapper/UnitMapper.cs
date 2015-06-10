using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class UnitMapper : ODM2MapperQueryable
    {
        public UnitMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Unit Map(SampleFileData sample, Result result)
        {
            var entity = this.Scaffold(sample);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, result);
        }

        public Unit Map(ChemistryFileData chemistry, Result result)
        {
            var entity = this.Scaffold(chemistry);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, result);
        }

        public Unit Scaffold(SampleFileData sample)
        {
            var unit = new Unit();

            unit.UnitsTypeCV = string.Empty;
            unit.UnitsName = string.Empty;
            unit.UnitsAbbreviation = string.Empty;

            return unit;
        }

        public Unit Scaffold(ChemistryFileData chemistry)
        {
            var unit = new Unit();

            string resultUnit = chemistry.ResultUnit;

            if (string.IsNullOrEmpty(resultUnit))
            {
                throw new ArgumentNullException();
            }

            const int unitAbbrevLength = 2;

            unit.UnitsTypeCV = resultUnit;
            unit.UnitsAbbreviation = (resultUnit.Length > unitAbbrevLength) ? resultUnit.Substring(0, unitAbbrevLength) : resultUnit;
            unit.UnitsName = resultUnit;

            return unit;
        }

        public Unit CheckDuplicate(Unit entity)
        {
            return this.GetDbMatch(entity, x =>
                x.UnitsName.Equals(entity.UnitsName)
            );
        }


        public Unit Link(Unit entity, Result result)
        {
            entity.Results.Add(result);

            return entity;
        }
    }
}
