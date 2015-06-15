using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ResultMapper : ESDATMapper
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "liquidAqueous";

        // Mappers
        private UnitMapper _unitMapper;
        private VariableMapper _variableMapper;
        private DatasetsResultMapper _DatasetsResultMapper;
        private ProcessingLevelMapper _processingLevelMapper;
        private MeasurementResultMapper _measurementResultMapper;

        public ResultMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _unitMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Unit)) as UnitMapper;
            _variableMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Variable)) as VariableMapper;
            _DatasetsResultMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(DatasetsResult)) as DatasetsResultMapper;
            _processingLevelMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelMapper;
            _measurementResultMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(MeasurementResult)) as MeasurementResultMapper;
        }

        public Result Map(SampleFileData sample)
        {
            var result = Scaffold(sample);

            // Unit
            var unit = _unitMapper.Map(sample);
            _linker.Link(result, unit);

            // Variable
            var variable = _variableMapper.Map(sample);
            _linker.Link(result, variable);

            // Processing Level
            var processingLevel = _processingLevelMapper.Map(result);
            _linker.Link(result, processingLevel);

            return result;
        }

        public Result Map(ChemistryFileData chemistry)
        {
            var result = Scaffold(chemistry);

            // Unit
            var unit = _unitMapper.Map(chemistry);
            _linker.Link(result, unit);

            // Variable
            var variable = _variableMapper.Map(chemistry);
            _linker.Link(result, variable);

            // Datasets Result
            var datasetsResult = _DatasetsResultMapper.Map(chemistry);
            _linker.Link(result, datasetsResult);

            // Processing Level
            var processingLevel = _processingLevelMapper.Map(result);
            _linker.Link(result, processingLevel);

            // Measurement Result
            var measurementResult = _measurementResultMapper.Map(chemistry);
            _linker.Link(result, measurementResult);

            return result;
        }

        public Result Scaffold(SampleFileData sample)
        {
            var result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = sample.SampledDateTime;
            result.SampledMediumCV = string.IsNullOrEmpty(sample.MatrixType) ? SampledMediumCV : sample.MatrixType;
            result.ValueCount = 1;

            return result;
        }

        public Result Scaffold(ChemistryFileData chemistry)
        {
            var result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            return result;
        }
    }
}
