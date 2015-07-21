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
            var entity = Draft(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Unit Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Unit();

            string resultUnit = chemistry.ResultUnit;

            entity.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVChemistry;
            entity.UnitsAbbreviation = Abbereviate(resultUnit);
            entity.UnitsName = resultUnit;

            Validate(entity);

            return entity;
        }
    }
}
