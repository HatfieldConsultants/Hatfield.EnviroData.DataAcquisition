using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.WQDataProfile;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATChemistryMapperFactory
    {
        public IWQDefaultValueProvider WQDefaultValueProvider { get; set; }
        public ChemistryActionMapper ActionMapper { get; protected set; }
        public ActionByMapper ActionByMapper { get; protected set; }
        public AffiliationMapper AffiliationMapper { get; protected set; }
        public DatasetMapper DatasetMapper { get; protected set; }
        public DatasetsResultMapper DatasetsResultMapper { get; protected set; }
        public ChemistryFeatureActionMapper FeatureActionMapper { get; protected set; }
        public ChemistryMeasurementResultMapper MeasurementResultMapper { get; protected set; }
        public ChemistryMeasurementResultValueMapper MeasurementResultValueMapper { get; protected set; }
        public ChemistryMethodMapper MethodMapper { get; protected set; }
        public ChemistryOrganizationMapper OrganizationMapper { get; protected set; }
        public PersonMapper PersonMapper { get; protected set; }
        public ProcessingLevelMapper ProcessingLevelMapper { get; protected set; }
        public RelatedActionMapper RelatedActionMapper { get; protected set; }
        public ChemistryResultMapper ResultMapper { get; protected set; }
        public ChemistrySamplingFeatureMapper SamplingFeatureMapper { get; protected set; }
        public ChemistryUnitMapper UnitMapper { get; protected set; }
        public ChemistryVariableMapper VariableMapper { get; protected set; }

        public ESDATChemistryMapperFactory(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
        {
            this.WQDefaultValueProvider = WQDefaultValueProvider;

            ActionMapper = new ChemistryActionMapper(duplicateChecker, this, WQDefaultValueProvider, wayToHandleNewData);
            ActionByMapper = new ActionByMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            AffiliationMapper = new AffiliationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            AffiliationMapper.SetBackingStore(new List<Affiliation>());

            DatasetMapper = new DatasetMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            DatasetsResultMapper = new DatasetsResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            FeatureActionMapper = new ChemistryFeatureActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            
            MeasurementResultMapper = new ChemistryMeasurementResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            MeasurementResultValueMapper = new ChemistryMeasurementResultValueMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            MethodMapper = new ChemistryMethodMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            MethodMapper.SetBackingStore(new List<Method>());

            OrganizationMapper = new ChemistryOrganizationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            OrganizationMapper.SetBackingStore(new List<Organization>());

            PersonMapper = new PersonMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            PersonMapper.SetBackingStore(new List<Person>());

            ProcessingLevelMapper = new ProcessingLevelMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            ProcessingLevelMapper.SetBackingStore(new List<ProcessingLevel>());

            RelatedActionMapper = new RelatedActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            ResultMapper = new ChemistryResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);

            SamplingFeatureMapper = new ChemistrySamplingFeatureMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            SamplingFeatureMapper.SetBackingStore(new List<SamplingFeature>());

            UnitMapper = new ChemistryUnitMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            UnitMapper.SetBackingStore(new List<Unit>());

            VariableMapper = new ChemistryVariableMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData);
            VariableMapper.SetBackingStore(new List<Variable>());
        }
    }
}
