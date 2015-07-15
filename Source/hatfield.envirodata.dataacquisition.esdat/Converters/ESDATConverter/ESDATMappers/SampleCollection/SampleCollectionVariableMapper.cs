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
        public SampleCollectionVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Variable Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Variable Scaffold(ESDATModel esdatModel)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = _WQDefaultValueProvider.DefaultVariableTypeCVSampleCollection;
            variable.VariableCode = _WQDefaultValueProvider.DefaultVariableCode;
            variable.VariableNameCV = _WQDefaultValueProvider.DefaultVariableNameCV;
            variable.SpeciationCV = _WQDefaultValueProvider.DefaultVariableSpeciationCV;
            variable.NoDataValue = _WQDefaultValueProvider.DefaultVariableNoDataValue;

            return variable;
        }
    }
}
