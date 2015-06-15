using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SamplingFeatureMapper : ESDATMapper
    {
        // Sample Collection Constants
        private const string SamplingFeatureTypeCVSampleCollection = "Site";

        // Chemistry Constants
        private const string SamplingFeatureTypeCVChemistry = "Specimen";

        public SamplingFeatureMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(entity);

            return entity;
        }

        public SamplingFeature Map(ChemistryFileData chemistry)
        {
            var entity = Scaffold(chemistry);
            entity = GetDuplicate(entity);

            return entity;
        }

        public SamplingFeature Scaffold(ESDATModel esdatModel)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVSampleCollection;
            samplingFeature.SamplingFeatureCode = string.Empty;

            return samplingFeature;
        }

        public SamplingFeature Scaffold(ChemistryFileData chemistry)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVChemistry;
            samplingFeature.SamplingFeatureCode = string.Empty;

            return samplingFeature;
        }

        public SamplingFeature GetDuplicate(SamplingFeature entity)
        {
            return GetDuplicate(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV)
            );
        }
    }
}
