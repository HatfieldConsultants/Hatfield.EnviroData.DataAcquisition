using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SamplingFeatureConverter : ESDATDataConverterBase
    {
        // Sample Collection Constants
        private const string SamplingFeatureTypeCVSampleCollection = "Site";

        // Chemistry Constants
        private const string SamplingFeatureTypeCVChemistry = "Specimen";

        public SamplingFeatureConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public SamplingFeature Convert(FeatureAction featureAction, ESDATModel esdatModel)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVSampleCollection;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.FeatureActions.Add(featureAction);

            return samplingFeature;
        }

        public SamplingFeature Convert(FeatureAction featureAction, ChemistryFileData chemistry)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVChemistry;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.FeatureActions.Add(featureAction);

            return samplingFeature;
        }
    }
}
