using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class UnitConverter : ODM2ActionConverter
    {
        public UnitConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Unit Convert(Result result, SampleFileData sample)
        {
            Unit unit = new Unit();

            unit.UnitsTypeCV = string.Empty;
            unit.UnitsName = string.Empty;
            unit.UnitsAbbreviation = string.Empty;
            unit.Results.Add(result);

            return unit;
        }

        public Unit Convert(Result result, ChemistryFileData chemistry)
        {
            Unit unit = new Unit();

            string resultUnit = chemistry.ResultUnit;

            if (!string.IsNullOrEmpty(resultUnit))
            {
                const int unitAbbrevLength = 2;

                unit.UnitsTypeCV = resultUnit;
                unit.UnitsAbbreviation = (resultUnit.Length > unitAbbrevLength) ? resultUnit.Substring(0, unitAbbrevLength) : resultUnit;
                unit.UnitsName = resultUnit;
                unit.Results.Add(result);
            }

            return unit;
        }
    }
}
