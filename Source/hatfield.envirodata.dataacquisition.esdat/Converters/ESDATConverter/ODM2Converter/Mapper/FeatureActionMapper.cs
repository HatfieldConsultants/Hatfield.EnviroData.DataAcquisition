using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class FeatureActionMapper : ODM2MapperBase
    {
        public FeatureActionMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public FeatureAction Map(ESDATModel esdatModel, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(esdatModel);

            // Sampling Feature
            var samplingFeatureMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(SamplingFeature)) as SamplingFeatureMapper;
            var samplingFeature = samplingFeatureMapper.Map(esdatModel, entity);

            // Each Feature Action can contain many results (Samples)
            var resultConverter = factory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultMapper;

            foreach (SampleFileData sample in esdatModel.SampleFileData)
            {
                Result result = resultConverter.Map(sample, factory);
                
                entity.Results.Add(result);
            }

            return this.Link(entity, samplingFeature, null);
        }

        public FeatureAction Map(ChemistryFileData chemistry, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(chemistry);

            // Sampling Feature
            var samplingFeatureMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(SamplingFeature)) as SamplingFeatureMapper;
            var samplingFeature = samplingFeatureMapper.Map(chemistry, entity);

            // Each Feature Action contains 1 Result (Chemistry)
            var resultConverter = factory.BuildDataConverter(typeof(ESDATModel), typeof(Result)) as ResultMapper;
            var result = resultConverter.Map(chemistry, factory);

            return this.Link(entity, samplingFeature, result);
        }

        public FeatureAction Scaffold(ESDATModel esdatModel)
        {
            return new FeatureAction();
        }

        public FeatureAction Scaffold(ChemistryFileData chemistry)
        {
            return new FeatureAction();
        }

        public FeatureAction Link(FeatureAction entity, SamplingFeature samplingFeature, Result result)
        {
            entity.SamplingFeature = samplingFeature;
            entity.SamplingFeatureID = samplingFeature.SamplingFeatureID;

            entity.Results.Add(result);

            return entity;
        }
    }
}
