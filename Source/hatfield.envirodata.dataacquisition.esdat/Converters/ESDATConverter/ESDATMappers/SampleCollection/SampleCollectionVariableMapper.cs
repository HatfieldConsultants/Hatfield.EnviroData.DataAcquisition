using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionVariableMapper : VariableMapperBase, IESDATSampleCollectionMapper<Variable>
    {
        public SampleCollectionVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Variable Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Variable Draft(ESDATModel esdatModel)
        {
            var entity = new Variable();

            entity.VariableTypeCV = _WQDefaultValueProvider.DefaultVariableTypeCVSampleCollection;
            entity.VariableCode = _WQDefaultValueProvider.DefaultVariableCode;
            entity.VariableNameCV = _WQDefaultValueProvider.DefaultVariableNameCV;
            entity.SpeciationCV = _WQDefaultValueProvider.DefaultVariableSpeciationCV;
            entity.NoDataValue = _WQDefaultValueProvider.DefaultVariableNoDataValue;

            Validate(entity);

            return entity;
        }
    }
}
