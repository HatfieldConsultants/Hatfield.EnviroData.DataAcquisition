using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATSampleCollectionMapperSingletonFactory : ESDATMapperSingletonFactoryBase
    {
        public ESDATSampleCollectionMapperSingletonFactory(ESDATSampleCollectionParameters parameters)
        {
            ActionByMapper = new ActionByMapper(parameters);
            ActionMapper = new SampleCollectionActionMapper(this, parameters);
            AffiliationMapper = new AffiliationMapper(parameters);
            DatasetMapper = new DatasetMapper(parameters);
            DatasetsResultMapper = new DatasetsResultMapper(parameters);
            FeatureActionMapper = new SampleCollectionFeatureActionMapper(parameters);
            MethodMapper = new SampleCollectionMethodMapper(parameters);
            OrganizationMapper = new SampleCollectionOrganizationMapper(parameters);
            PersonMapper = new PersonMapper(parameters);
            ProcessingLevelMapper = new ProcessingLevelMapper(parameters);
            RelatedActionMapper = new RelatedActionMapper(parameters);
            ResultMapper = new SampleCollectionResultMapper(parameters);
            SamplingFeatureMapper = new SampleCollectionSamplingFeatureMapper(parameters);
            UnitMapper = new SampleCollectionUnitMapper(parameters);
            VariableMapper = new SampleCollectionVariableMapper(parameters);
        }
    }
}
