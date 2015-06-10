using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ResultMapper : ODM2MapperQueryable
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "liquidAqueous";

        public ResultMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Result Map(SampleFileData sample, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(sample);

            // Unit
            var unitMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitMapper;
            var unit = unitMapper.Map(sample, entity);

            // Variable
            var variableMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableMapper;
            var variable = variableMapper.Map(sample, entity);

            // Processing Level
            var processingLevelMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelMapper;
            var processingLevel = processingLevelMapper.Map(entity);

            return this.Link(entity, unit, variable, null, processingLevel, null);
        }

        public Result Map(ChemistryFileData chemistry, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(chemistry);

            // Unit
            var unitMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitMapper;
            var unit = unitMapper.Map(chemistry, entity);

            // Variable
            var variableMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableMapper;
            var variable = variableMapper.Map(chemistry, entity);

            // Datasets Results
            var datasetsResultMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(DataSetsResult)) as DataSetsResultMapper;
            var dataSetsResult = datasetsResultMapper.Map(chemistry, entity, factory);

            // Processing Level
            var processingLevelMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelMapper;
            var processingLevel = processingLevelMapper.Map(entity);

            // Measurement Result
            var measurementResultMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResult)) as MeasurementResultMapper;
            var measurementResult = measurementResultMapper.Map(chemistry, unit, factory);

            return this.Link(entity, unit, variable, dataSetsResult, processingLevel, measurementResult);
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

        public Result CheckDuplicate(Result entity)
        {
            return this.GetDbMatch(entity, x =>
                x.ResultID.Equals(entity.ResultID)
            );
        }

        public Result Link(Result entity, Unit unit, Variable variable, DataSetsResult dataSetsResult, ProcessingLevel processingLevel, MeasurementResult measurementResult)
        {
            if (unit != null)
            {
                entity.Unit = unit;
                entity.UnitsID = unit.UnitsID;
            }

            if (variable != null)
            {
                entity.Variable = variable;
                entity.VariableID = variable.VariableID;
            }

            if (dataSetsResult != null)
            {
                entity.DataSetsResults.Add(dataSetsResult);
            }

            if (processingLevel != null)
            {
                entity.ProcessingLevel = processingLevel;
                entity.ProcessingLevelID = processingLevel.ProcessingLevelID;
            }

            if (measurementResult != null)
            {
                entity.MeasurementResult = measurementResult;
            }

            return entity;
        }
    }
}
