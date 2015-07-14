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
        // Sample Collection Constants
        private const string UnitsTypeCVSampleCollection = "Dimensionless";

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

            unit.UnitsTypeCV = UnitsTypeCVSampleCollection;
            unit.UnitsAbbreviation = AbbereviateUnit(UnitsTypeCVSampleCollection);
            unit.UnitsName = UnitsTypeCVSampleCollection;

            return unit;
        }
    }
}
