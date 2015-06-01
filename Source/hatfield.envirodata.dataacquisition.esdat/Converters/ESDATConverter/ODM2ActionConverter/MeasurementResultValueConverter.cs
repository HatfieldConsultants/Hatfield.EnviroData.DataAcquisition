using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultValueConverter : ESDATDataConverterBase
    {
        public MeasurementResultValueConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public MeasurementResultValue Convert(SampleFileData sample)
        {
            var measurementResultValue = new MeasurementResultValue();

            if (sample.SampledDateTime.HasValue)
            {
                measurementResultValue.ValueDateTime = sample.SampledDateTime.Value;
            }

            return measurementResultValue;
        }

        public MeasurementResultValue Convert(ChemistryFileData chemistry)
        {
            var measurementResultValue = new MeasurementResultValue();

            if (chemistry.Result.HasValue)
            {
                measurementResultValue.DataValue = (double)chemistry.Result;
            }
            
            measurementResultValue.ValueDateTime = chemistry.AnalysedDate;

            return measurementResultValue;
        }
    }
}
