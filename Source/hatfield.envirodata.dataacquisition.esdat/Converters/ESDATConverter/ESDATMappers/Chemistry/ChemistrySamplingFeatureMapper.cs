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
        public ChemistrySamplingFeatureMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public SamplingFeature Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public SamplingFeature Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            SamplingFeature samplingFeature = new SamplingFeature();

            samplingFeature.SamplingFeatureTypeCV = _WQDefaultValueProvider.DefaultSamplingFeatureTypeCVChemistry;
            samplingFeature.SamplingFeatureCode = string.Empty;
            samplingFeature.SamplingFeatureUUID = new Guid();

            LogScaffoldingComplete(this);

            return samplingFeature;
        }
    }
}
