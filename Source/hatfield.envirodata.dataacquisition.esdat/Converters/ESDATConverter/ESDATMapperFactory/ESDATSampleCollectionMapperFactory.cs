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
        public ResultExtensionPropertyValueMapper ResultExtensionPropertyValueMapper { get; protected set; }
        public ExtensionPropertyMapper ExtensionPropertyMapper { get; protected set; }

        public ESDATSampleCollectionMapperFactory(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
        {
            this.WQDefaultValueProvider = WQDefaultValueProvider;
            
            var chemistryFactory = new ESDATChemistryMapperFactory(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            ActionByMapper = new ActionByMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            AffiliationMapper = new AffiliationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            AffiliationMapper.BackingStore = new List<Affiliation>();

            DatasetMapper = new DatasetMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            DatasetMapper.BackingStore = new List<Dataset>();

            DatasetsResultMapper = new DatasetsResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            FeatureActionMapper = new SampleCollectionFeatureActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            MethodMapper = new SampleCollectionMethodMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            MethodMapper.BackingStore = new List<Method>();

            OrganizationMapper = new SampleCollectionOrganizationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            OrganizationMapper.BackingStore = new List<Organization>();

            PersonMapper = new PersonMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            PersonMapper.BackingStore = new List<Person>();

            ProcessingLevelMapper = new ProcessingLevelMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ProcessingLevelMapper.BackingStore = new List<ProcessingLevel>();

            RelatedActionMapper = new RelatedActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ResultMapper = new SampleCollectionResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            SamplingFeatureMapper = new SampleCollectionSamplingFeatureMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            SamplingFeatureMapper.BackingStore = new List<SamplingFeature>();

            UnitMapper = new SampleCollectionUnitMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            UnitMapper.BackingStore = new List<Unit>();

            VariableMapper = new SampleCollectionVariableMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            VariableMapper.BackingStore = new List<Variable>();

            ResultExtensionPropertyValueMapper = new ResultExtensionPropertyValueMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            ExtensionPropertyMapper = new ExtensionPropertyMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ExtensionPropertyMapper.BackingStore = new List<ExtensionProperty>();
        }
    }
}
