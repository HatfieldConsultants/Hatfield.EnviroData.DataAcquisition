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
        public SampleCollectionUnitMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Unit Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Unit Scaffold(ESDATModel esdatModel)
        {
            var unit = new Unit();

            unit.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;
            unit.UnitsAbbreviation = Abbereviate(_WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection);
            unit.UnitsName = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;

            return unit;
        }
    }
}
