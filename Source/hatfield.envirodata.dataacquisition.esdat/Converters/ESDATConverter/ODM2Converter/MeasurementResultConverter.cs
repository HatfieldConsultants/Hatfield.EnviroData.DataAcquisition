using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultConverter : ODM2ConverterBase
    {
        // Constants
        private const string CensorCodeCV = "notCensored";
        private const string QualityCodeCV = "unknown";
        private const string AggregationStatisticCV = "unknown";

        public MeasurementResultConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public MeasurementResult Convert(SampleFileData sample, Unit unit, IESDATDataConverterFactory converterFactory)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            var measurementResultValueConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResultValue)) as MeasurementResultValueConverter;
            var measurementResultValue = measurementResultValueConverter.Convert(sample);
            measurementResult.MeasurementResultValues.Add(measurementResultValue);

            measurementResult.Unit = unit;

            return measurementResult;
        }

        public MeasurementResult Convert(ChemistryFileData chemistry, Unit unit, IESDATDataConverterFactory converterFactory)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = CensorCodeCV;
            measurementResult.QualityCodeCV = QualityCodeCV;
            measurementResult.AggregationStatisticCV = AggregationStatisticCV;

            var measurementResultValueConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResultValue)) as MeasurementResultValueConverter;
            var measurementResultValue = measurementResultValueConverter.Convert(chemistry);
            measurementResult.MeasurementResultValues.Add(measurementResultValue);

            measurementResult.Unit = unit;

            return measurementResult;
        }
    }
}
