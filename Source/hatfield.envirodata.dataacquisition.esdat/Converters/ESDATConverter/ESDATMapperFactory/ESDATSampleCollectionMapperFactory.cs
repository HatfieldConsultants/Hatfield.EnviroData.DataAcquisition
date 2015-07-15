using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.WQDataProfile;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATSampleCollectionMapperFactory
    {
        public IWQDefaultValueProvider WQDefaultValueProvider { get; set; }
        public ActionByMapper ActionByMapper { get; protected set; }
        public AffiliationMapper AffiliationMapper { get; protected set; }
        public DatasetMapper DatasetMapper { get; protected set; }
        public DatasetsResultMapper DatasetsResultMapper { get; protected set; }
        public SampleCollectionFeatureActionMapper FeatureActionMapper { get; protected set; }
        public SampleCollectionMethodMapper MethodMapper { get; protected set; }
        public SampleCollectionOrganizationMapper OrganizationMapper { get; protected set; }
        public PersonMapper PersonMapper { get; protected set; }
        public ProcessingLevelMapper ProcessingLevelMapper { get; protected set; }
        public RelatedActionMapper RelatedActionMapper { get; protected set; }
        public SampleCollectionResultMapper ResultMapper { get; protected set; }
        public SampleCollectionSamplingFeatureMapper SamplingFeatureMapper { get; protected set; }
        public SampleCollectionUnitMapper UnitMapper { get; protected set; }
        public SampleCollectionVariableMapper VariableMapper { get; protected set; }

        public ESDATSampleCollectionMapperFactory(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
        {
            this.WQDefaultValueProvider = WQDefaultValueProvider;

            var chemistryFactory = new ESDATChemistryMapperFactory(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            ActionByMapper = new ActionByMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            AffiliationMapper = new AffiliationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            AffiliationMapper.SetBackingStore(new List<Affiliation>());

            DatasetMapper = new DatasetMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            DatasetsResultMapper = new DatasetsResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            FeatureActionMapper = new SampleCollectionFeatureActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            MethodMapper = new SampleCollectionMethodMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            MethodMapper.SetBackingStore(new List<Method>());

            OrganizationMapper = new SampleCollectionOrganizationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            OrganizationMapper.SetBackingStore(new List<Organization>());

            PersonMapper = new PersonMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            PersonMapper.SetBackingStore(new List<Person>());

            ProcessingLevelMapper = new ProcessingLevelMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            ProcessingLevelMapper.SetBackingStore(new List<ProcessingLevel>());

            RelatedActionMapper = new RelatedActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            ResultMapper = new SampleCollectionResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            SamplingFeatureMapper = new SampleCollectionSamplingFeatureMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            SamplingFeatureMapper.SetBackingStore(new List<SamplingFeature>());

            UnitMapper = new SampleCollectionUnitMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            UnitMapper.SetBackingStore(new List<Unit>());

            VariableMapper = new SampleCollectionVariableMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            VariableMapper.SetBackingStore(new List<Variable>());
        }
    }
}
