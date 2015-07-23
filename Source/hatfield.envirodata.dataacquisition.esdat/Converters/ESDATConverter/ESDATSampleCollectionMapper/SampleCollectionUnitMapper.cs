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
        public SampleCollectionUnitMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Unit Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Unit Draft(ESDATModel esdatModel)
        {
            var entity = new Unit();

            entity.UnitsTypeCV = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;
            entity.UnitsAbbreviation = Abbereviate(_WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection);
            entity.UnitsName = _WQDefaultValueProvider.DefaultUnitsTypeCVSampleCollection;

            Validate(entity);

            return entity;
        }
    }
}
