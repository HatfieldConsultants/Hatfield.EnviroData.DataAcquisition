using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToFeatureAction : ESDATConverterToODMAction
    {
        public ESDATConverterToFeatureAction(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FeatureAction Convert(ESDATModel esdatModel, ESDATConverterToSamplingFeature samplingFeatureConverter, ESDATConverterToResult resultConverter, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            FeatureAction featureAction = new FeatureAction();

            // Sampling Feature
            featureAction.SamplingFeature = samplingFeatureConverter.Convert(featureAction, esdatModel);

            // Each Feature Action can contain many results (Samples)
            foreach (SampleFileData sample in esdatModel.SampleFileData)
            {
                Result result = resultConverter.Convert(sample, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);
                
                featureAction.Results.Add(result);
            }

            return featureAction;
        }

        public FeatureAction Convert(ChemistryFileData chemistry, ESDATConverterToSamplingFeature samplingFeatureConverter, ESDATConverterToResult resultConverter, ESDATConverterToDatasetsResult datasetsResultConverter, ESDATConverterToDataset datasetConverter, ESDATConverterToProcessingLevel processingLevelConverter, ESDATConverterToUnit unitConverter, ESDATConverterToVariable variableConverter, ESDATConverterToMeasurementResult measurementResultConverter, ESDATConverterToMeasurementResultValue measurementResultValueConverter)
        {
            FeatureAction featureAction = new FeatureAction();

            // Sampling Feature
            featureAction.SamplingFeature = samplingFeatureConverter.Convert(featureAction, chemistry);

            // Each Feature Action contains 1 Result (Chemistry)
            Result result = resultConverter.Convert(chemistry, datasetsResultConverter, datasetConverter, processingLevelConverter, unitConverter, variableConverter, measurementResultConverter, measurementResultValueConverter);

            featureAction.Results.Add(result);

            return featureAction;
        }
    }
}
