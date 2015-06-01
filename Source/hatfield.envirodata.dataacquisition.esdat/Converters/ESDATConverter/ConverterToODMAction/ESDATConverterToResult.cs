using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToResult : ESDATConverterToODMAction
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "liquidAqueous";

        public ESDATConverterToResult(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Result Convert(SampleFileData sample, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            Result result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = sample.SampledDateTime;
            result.SampledMediumCV = string.IsNullOrEmpty(sample.MatrixType) ? SampledMediumCV : sample.MatrixType;
            result.ValueCount = 1;

            // Unit
            result.Unit = unitConverter.Convert(result, sample);

            // Variable
            result.Variable = variableConverter.Convert(result, sample);

            // Processing Level
            result.ProcessingLevel = processingLevelConverter.Convert(result);

            return result;
        }

        public Result Convert(ChemistryFileData chemistry, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            Result result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            // Unit
            result.Unit = unitConverter.Convert(result, chemistry);

            // Variable
            result.Variable = variableConverter.Convert(result, chemistry);

            // Datasets Results
            var dataSetsResult = datasetsResultConverter.Convert(result, chemistry, datasetConverter);
            result.DataSetsResults.Add(dataSetsResult);

            // Processing Level
            result.ProcessingLevel = processingLevelConverter.Convert(result);

            // Measurement Result
            result.MeasurementResult = measurementResultConverter.Convert(chemistry, measurementResultValueConverter, result.Unit);

            return result;
        }
    }
}
