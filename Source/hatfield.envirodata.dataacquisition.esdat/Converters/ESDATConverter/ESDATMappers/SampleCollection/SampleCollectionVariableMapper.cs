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
        // Shared Constants
        private const string SpeciationCV = "Unknown";
        private const int NoDataValue = -9999;

        // Sample Collection Constants
        private const string VariableTypeCVSampleCollection = "Unknown";

        public SampleCollectionVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Variable Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_duplicateChecker, _wayToHandleNewData, entity);

            return entity;
        }

        public Variable Scaffold(ESDATModel esdatModel)
        {
            Variable variable = new Variable();

            variable.VariableTypeCV = VariableTypeCVSampleCollection;
            variable.VariableCode = string.Empty;
            variable.VariableNameCV = string.Empty;
            variable.SpeciationCV = SpeciationCV;
            variable.NoDataValue = NoDataValue;

            return variable;
        }
    }
}
