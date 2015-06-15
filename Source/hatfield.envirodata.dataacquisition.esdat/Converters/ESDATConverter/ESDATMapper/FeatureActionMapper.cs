using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class FeatureActionMapper : ESDATMapper
    {

        // Mappers
        private SamplingFeatureMapper _samplingFeatureMapper;
        private ResultMapper _resultMapper;

        public FeatureActionMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _samplingFeatureMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(SamplingFeature)) as SamplingFeatureMapper;
            _resultMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Result)) as ResultMapper;
        }

        public FeatureAction Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            // Sampling Feature
            var samplingFeature = _samplingFeatureMapper.Map(esdatModel);
            _linker.Link(entity, samplingFeature);

            // Each Feature Action can contain many results (Samples)
            foreach (SampleFileData sample in esdatModel.SampleFileData)
            {
                Result result = _resultMapper.Map(sample);

                _linker.Link(entity, result);
            }

            return entity;
        }

        public FeatureAction Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);

            // Sampling Feature
            var samplingFeature = _samplingFeatureMapper.Map(chemistry);
            _linker.Link(entity, samplingFeature);

            // Each Feature Action contains 1 Result (Chemistry)
            var result = _resultMapper.Map(chemistry);
            _linker.Link(entity, result);

            return entity;
        }

        public FeatureAction Scaffold(ESDATModel esdatModel)
        {
            return new FeatureAction();
        }

        public FeatureAction Scaffold(ChemistryFileData chemistry)
        {
            return new FeatureAction();
        }
    }
}
