using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class FeatureActionConverter : ESDATDataConverterBase
    {
        public FeatureActionConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FeatureAction Convert(ESDATModel esdatModel, SamplingFeatureConverter samplingFeatureConverter, ResultConverter resultConverter, DataSetsResultConverter datasetsResultConverter, DatasetConverter datasetConverter, ProcessingLevelConverter processingLevelConverter, UnitConverter unitConverter, VariableConverter variableConverter, MeasurementResultConverter measurementResultConverter, MeasurementResultValueConverter measurementResultValueConverter)
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

        public FeatureAction Convert(ChemistryFileData chemistry, SamplingFeatureConverter samplingFeatureConverter, ResultConverter resultConverter, DataSetsResultConverter datasetsResultConverter, DatasetConverter datasetConverter, ProcessingLevelConverter processingLevelConverter, UnitConverter unitConverter, VariableConverter variableConverter, MeasurementResultConverter measurementResultConverter, MeasurementResultValueConverter measurementResultValueConverter)
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
