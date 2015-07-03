using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionSamplingFeatureMapper : SamplingFeatureMapperBase
    {
        // Sample Collection Constants
        private const string SamplingFeatureTypeCVSampleCollection = "Site";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionSamplingFeatureMapper(ESDATSampleCollectionParameters parameters)
        {
            _parameters = parameters;
        }

        public override SamplingFeature Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override SamplingFeature Scaffold()
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVSampleCollection;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.SamplingFeatureUUID = new Guid();

            return samplingFeature;
        }
    }
}
