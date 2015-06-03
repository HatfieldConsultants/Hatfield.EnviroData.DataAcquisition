using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class FeatureActionConverter : ODM2ConverterBase
    {
        public FeatureActionConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public FeatureAction Convert(ESDATModel esdatModel, IESDATDataConverterFactory converterFactory)
        {
            FeatureAction featureAction = new FeatureAction();

            // Sampling Feature
            var samplingFeatureConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(SamplingFeature)) as SamplingFeatureConverter;
            featureAction.SamplingFeature = samplingFeatureConverter.Convert(esdatModel, featureAction);

            // Each Feature Action can contain many results (Samples)
            var resultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultConverter;

            foreach (SampleFileData sample in esdatModel.SampleFileData)
            {
                Result result = resultConverter.Convert(sample, converterFactory);
                
                featureAction.Results.Add(result);
            }

            return featureAction;
        }

        public FeatureAction Convert(ChemistryFileData chemistry, IESDATDataConverterFactory converterFactory)
        {
            FeatureAction featureAction = new FeatureAction();

            // Sampling Feature
            var samplingFeatureConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(SamplingFeature)) as SamplingFeatureConverter;
            featureAction.SamplingFeature = samplingFeatureConverter.Convert(chemistry, featureAction);

            // Each Feature Action contains 1 Result (Chemistry)
            var resultConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultConverter;

            Result result = resultConverter.Convert(chemistry, converterFactory);

            featureAction.Results.Add(result);

            return featureAction;
        }
    }
}
