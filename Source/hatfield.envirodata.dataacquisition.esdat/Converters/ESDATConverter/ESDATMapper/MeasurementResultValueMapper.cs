using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultValueMapper : ESDATMapper
    {
        public MeasurementResultValueMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public MeasurementResultValue Map(SampleFileData sample)
        {
            return Scaffold(sample);
        }

        public MeasurementResultValue Map(ChemistryFileData chemistry)
        {
            return Scaffold(chemistry);
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
