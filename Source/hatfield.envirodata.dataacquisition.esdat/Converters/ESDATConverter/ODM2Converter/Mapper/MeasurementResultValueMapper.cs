using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultValueMapper : ODM2MapperBase
    {
        public MeasurementResultValueMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public MeasurementResultValue Map(SampleFileData sample)
        {
            return this.Scaffold(sample);
        }

        public MeasurementResultValue Map(ChemistryFileData chemistry)
        {
            return this.Scaffold(chemistry);
        }

        public MeasurementResultValue Scaffold(SampleFileData sample)
        {
            var measurementResultValue = new MeasurementResultValue();

            if (sample.SampledDateTime.HasValue)
            {
                measurementResultValue.ValueDateTime = sample.SampledDateTime.Value;
            }

            return measurementResultValue;
        }

        public MeasurementResultValue Scaffold(ChemistryFileData chemistry)
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
