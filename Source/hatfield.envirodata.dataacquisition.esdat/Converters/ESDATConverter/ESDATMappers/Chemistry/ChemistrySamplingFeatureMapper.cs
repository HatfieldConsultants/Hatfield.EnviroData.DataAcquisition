using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistrySamplingFeatureMapper : SamplingFeatureMapperBase, IESDATChemistryMapper<SamplingFeature>
    {
        // Chemistry Constants
        private const string SamplingFeatureTypeCVChemistry = "Specimen";

        public ChemistrySamplingFeatureMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_duplicateChecker, _wayToHandleNewData, entity);

            return entity;
        }

        public SamplingFeature Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = SamplingFeatureTypeCVChemistry;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.SamplingFeatureUUID = new Guid();

            return samplingFeature;
        }
    }
}
