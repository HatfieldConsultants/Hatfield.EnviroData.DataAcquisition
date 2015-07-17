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
        public ChemistryUnitMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Unit Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public Unit Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var unit = new Unit();

            string resultUnit = chemistry.ResultUnit;

            if (string.IsNullOrEmpty(resultUnit))
            {
                var location = new MapperSourceLocation(this.ToString(), "ResultUnit");
                string message = "Value can not be null.";
                LogMappingError(location, message);
            }

            unit.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVChemistry;
            unit.UnitsAbbreviation = Abbereviate(resultUnit);
            unit.UnitsName = resultUnit;

            LogScaffoldingComplete(this);

            return unit;
        }
    }
}
