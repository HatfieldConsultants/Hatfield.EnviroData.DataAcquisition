using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class UnitMapper : ESDATMapper
    {
        public UnitMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public Unit Map(SampleFileData sample)
        {
            var entity = Scaffold(sample);
            entity = GetDuplicate(entity);

            return entity;
        }

        public Unit Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);
            entity = GetDuplicate(entity);

            return entity;
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

        public Unit GetDuplicate(Unit entity)
        {
            return GetDuplicate(entity, x =>
                x.UnitsName.Equals(entity.UnitsName)
            );
        }
    }
}
