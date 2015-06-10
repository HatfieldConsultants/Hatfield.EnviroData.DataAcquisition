using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultMapper : ODM2MapperBase
    {
        // Constants
        private const string CensorCodeCV = "notCensored";
        private const string QualityCodeCV = "unknown";
        private const string AggregationStatisticCV = "unknown";

        public MeasurementResultMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public MeasurementResult Map(SampleFileData sample, Unit unit, IESDATDataConverterFactory factory)
        {
            var measurementResult = this.Scaffold(sample);

            var measurementResultValueMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResultValue)) as MeasurementResultValueMapper;
            var measurementResultValue = measurementResultValueMapper.Map(sample);
            measurementResult.MeasurementResultValues.Add(measurementResultValue);

            measurementResult.Unit = unit;

            return measurementResult;
        }

        public MeasurementResult Map(ChemistryFileData chemistry, Unit unit, IESDATDataConverterFactory converterFactory)
        {
            var measurementResult = this.Scaffold(chemistry);

            var measurementResultValueMapper = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResultValue)) as MeasurementResultValueMapper;
            var measurementResultValue = measurementResultValueMapper.Map(chemistry);
            measurementResult.MeasurementResultValues.Add(measurementResultValue);

            measurementResult.Unit = unit;

            return measurementResult;
        }

        public MeasurementResult Scaffold(SampleFileData sample)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            return measurementResult;
        }

        public MeasurementResult Scaffold(ChemistryFileData chemistry)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            return measurementResult;
        }

        public MeasurementResult Link(MeasurementResult entity, MeasurementResultValue measurementResultValue, Unit unit)
        {
            entity.MeasurementResultValues.Add(measurementResultValue);
            entity.Unit = unit;

            return entity;
        }
    }
}
