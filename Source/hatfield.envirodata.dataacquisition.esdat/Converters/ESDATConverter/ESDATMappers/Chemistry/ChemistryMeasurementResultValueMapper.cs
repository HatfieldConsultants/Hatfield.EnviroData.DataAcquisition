using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMeasurementResultValueMapper : MeasurementResultValueMapperBase
    {
        protected ESDATChemistryParameters _parameters;

        public ChemistryMeasurementResultValueMapper(ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
        }


        public override MeasurementResultValue Map()
        {
            return Scaffold();
        }

        public override MeasurementResultValue Scaffold()
        {
            var measurementResultValue = new MeasurementResultValue();

            var chemistry = _parameters.ChemistryFileData;

            if (chemistry.Result.HasValue)
            {
                measurementResultValue.DataValue = (double)chemistry.Result;
            }

            measurementResultValue.ValueDateTime = chemistry.AnalysedDate;

            return measurementResultValue;
        }
    }
}
