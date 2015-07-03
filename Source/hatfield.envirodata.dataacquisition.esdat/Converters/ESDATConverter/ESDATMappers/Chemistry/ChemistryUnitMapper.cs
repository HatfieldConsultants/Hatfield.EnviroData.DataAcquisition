using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryUnitMapper : UnitMapperBase
    {
        protected ESDATChemistryParameters _parameters;

        public ChemistryUnitMapper(ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
        }

        public override Unit Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Unit Scaffold()
        {
            var unit = new Unit();

            var chemistry = _parameters.ChemistryFileData;

            string resultUnit = chemistry.ResultUnit;

            if (string.IsNullOrEmpty(resultUnit))
            {
                throw new ArgumentNullException("Please ensure that the chemistry result unit is not null.");
            }

            unit.UnitsTypeCV = resultUnit;
            unit.UnitsAbbreviation = AbbereviateUnit(resultUnit);
            unit.UnitsName = resultUnit;

            return unit;
        }
    }
}
