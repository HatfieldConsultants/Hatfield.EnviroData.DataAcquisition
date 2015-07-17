using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionUnitMapper : UnitMapperBase, IESDATSampleCollectionMapper<Unit>
    {
        public SampleCollectionUnitMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Unit Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public Unit Scaffold(ESDATModel esdatModel)
        {
            var unit = new Unit();

            unit.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;
            unit.UnitsAbbreviation = Abbereviate(_WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection);
            unit.UnitsName = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;

            LogScaffoldingComplete(this);

            return unit;
        }
    }
}
