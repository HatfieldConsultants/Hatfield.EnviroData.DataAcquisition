using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryUnitMapper : UnitMapperBase, IESDATChemistryMapper<Unit>
    {
        public ChemistryUnitMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Unit Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Unit Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var unit = new Unit();

            string resultUnit = chemistry.ResultUnit;

            if (string.IsNullOrEmpty(resultUnit))
            {
                throw new ArgumentNullException("Please ensure that the chemistry result unit is not null.");
            }

            unit.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVChemistry;
            unit.UnitsAbbreviation = Abbereviate(resultUnit);
            unit.UnitsName = resultUnit;

            return unit;
        }
    }
}
