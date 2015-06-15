using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MeasurementResultMapper : ESDATMapper
    {
        // Constants
        private const string CensorCodeCV = "notCensored";
        private const string QualityCodeCV = "unknown";
        private const string AggregationStatisticCV = "unknown";

        // Mappers
        private MeasurementResultValueMapper _measurementResultValueMapper;

        public MeasurementResultMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _measurementResultValueMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(MeasurementResultValue)) as MeasurementResultValueMapper;
        }

        public MeasurementResult Map(SampleFileData sample)
        {
            var entity = Scaffold(sample);

            var measurementResultValue = _measurementResultValueMapper.Map(sample);
            _linker.Link(entity, measurementResultValue);

            return entity;
        }

        public MeasurementResult Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);

            var measurementResultValue = _measurementResultValueMapper.Map(chemistry);
            _linker.Link(entity, measurementResultValue);

            return entity;
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
    }
}
