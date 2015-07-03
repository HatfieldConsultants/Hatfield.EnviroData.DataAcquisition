using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionVariableMapper : VariableMapperBase
    {
        // Shared Constants
        private const string SpeciationCV = "Unknown";
        private const int NoDataValue = -9999;

        // Sample Collection Constants
        private const string VariableTypeCVSampleCollection = "Unknown";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionVariableMapper(ESDATSampleCollectionParameters parameters)
        {
            _parameters = parameters;
        }

        public override Variable Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Variable Scaffold()
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
