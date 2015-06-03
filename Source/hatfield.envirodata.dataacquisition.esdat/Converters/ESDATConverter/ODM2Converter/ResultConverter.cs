using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ResultConverter : ODM2ConverterBase
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "liquidAqueous";

        public ResultConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Result Convert(SampleFileData sample, IESDATDataConverterFactory converterFactory)
        {
            Result result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = sample.SampledDateTime;
            result.SampledMediumCV = string.IsNullOrEmpty(sample.MatrixType) ? SampledMediumCV : sample.MatrixType;
            result.ValueCount = 1;

            // Unit
            var unitConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitConverter;
            result.Unit = unitConverter.Convert(sample, result);

            // Variable
            var variableConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableConverter;
            result.Variable = variableConverter.Convert(sample, result);

            // Processing Level
            var processingLevelConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelConverter;
            result.ProcessingLevel = processingLevelConverter.Convert(result);

            return result;
        }

        public Result Convert(ChemistryFileData chemistry, IESDATDataConverterFactory converterFactory)
        {
            Result result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            // Unit
            var unitConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Unit)) as UnitConverter;
            result.Unit = unitConverter.Convert(chemistry, result);

            // Variable
            var variableConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Variable)) as VariableConverter;
            result.Variable = variableConverter.Convert(chemistry, result);

            // Datasets Results
            var datasetsResultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSetsResult)) as DataSetsResultConverter;
            var dataSetsResult = datasetsResultConverter.Convert(chemistry, result, converterFactory);
            result.DataSetsResults.Add(dataSetsResult);

            // Processing Level
            var processingLevelConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(ProcessingLevel)) as ProcessingLevelConverter;
            result.ProcessingLevel = processingLevelConverter.Convert(result);

            // Measurement Result
            var measurementResultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(MeasurementResult)) as MeasurementResultConverter;
            result.MeasurementResult = measurementResultConverter.Convert(chemistry, result.Unit, converterFactory);

            return result;
        }
    }
}
