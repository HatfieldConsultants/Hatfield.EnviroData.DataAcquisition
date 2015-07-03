using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionUnitMapper : UnitMapperBase
    {
        // Sample Collection Constants
        private const string UnitsTypeCVSampleCollection = "dimensionless";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionUnitMapper(ESDATSampleCollectionParameters parameters)
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

            unit.UnitsTypeCV = UnitsTypeCVSampleCollection;
            unit.UnitsAbbreviation = AbbereviateUnit(UnitsTypeCVSampleCollection);
            unit.UnitsName = UnitsTypeCVSampleCollection;

            return unit;
        }
    }
}
