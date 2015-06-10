using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SamplingFeatureMapper : ODM2MapperQueryable
    {
        // Sample Collection Constants
        private const string SamplingFeatureTypeCVSampleCollection = "Site";

        // Chemistry Constants
        private const string SamplingFeatureTypeCVChemistry = "Specimen";

        public SamplingFeatureMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel, FeatureAction featureAction)
        {
            var entity = this.Scaffold(esdatModel);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, featureAction);
        }

        public SamplingFeature Map(ChemistryFileData chemistry, FeatureAction featureAction)
        {
            var entity = this.Scaffold(chemistry);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, featureAction);
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

        public SamplingFeature CheckDuplicate(SamplingFeature entity)
        {
            return this.GetDbMatch(entity, x =>
                x.SamplingFeatureTypeCV.Equals(entity.SamplingFeatureTypeCV)
            );
        }

        public SamplingFeature Link(SamplingFeature entity, FeatureAction featureAction)
        {
            entity.FeatureActions.Add(featureAction);

            return entity;
        }
    }
}
