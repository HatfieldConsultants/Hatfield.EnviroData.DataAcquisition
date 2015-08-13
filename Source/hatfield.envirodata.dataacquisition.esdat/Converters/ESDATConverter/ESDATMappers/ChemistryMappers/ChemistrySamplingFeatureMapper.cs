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
        public ChemistrySamplingFeatureMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public SamplingFeature Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new SamplingFeature();

            entity.SamplingFeatureTypeCV = _WQDefaultValueProvider.DefaultSamplingFeatureTypeCVChemistry;
            entity.SamplingFeatureCode = _WQDefaultValueProvider.DefaultSamplingFeatureCodeCVChemistry;
            entity.SamplingFeatureName = _WQDefaultValueProvider.DefaultSamplingFeatureNameChemistry;
            entity.SamplingFeatureUUID = _WQDefaultValueProvider.DefaultSamplingFeatureUUIDChemistry;

            Validate(entity);

            return entity;
        }
    }
}
