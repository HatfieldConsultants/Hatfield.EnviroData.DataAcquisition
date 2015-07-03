using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistrySamplingFeatureMapper : SamplingFeatureMapperBase
    {
        // Chemistry Constants
        private const string SamplingFeatureTypeCVChemistry = "Specimen";

        protected ESDATChemistryParameters _parameters;

        public ChemistrySamplingFeatureMapper(ESDATChemistryParameters parameters)
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

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVChemistry;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.SamplingFeatureUUID = new Guid();

            return samplingFeature;
        }
    }
}
