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
        public ResultExtensionPropertyValueMapper ResultExtensionPropertyValueMapper { get; protected set; }
        public ExtensionPropertyMapper ExtensionPropertyMapper { get; protected set; }

        public ESDATChemistryMapperFactory(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
        {
            this.WQDefaultValueProvider = WQDefaultValueProvider;

            ActionMapper = new ChemistryActionMapper(duplicateChecker, this, WQDefaultValueProvider, wayToHandleNewData, results);
            ActionByMapper = new ActionByMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            AffiliationMapper = new AffiliationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            AffiliationMapper.SetBackingStore(new List<Affiliation>());

            DatasetMapper = new DatasetMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            DatasetMapper.SetBackingStore(new List<Dataset>());

            DatasetsResultMapper = new DatasetsResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            FeatureActionMapper = new ChemistryFeatureActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            
            MeasurementResultMapper = new ChemistryMeasurementResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            MeasurementResultValueMapper = new ChemistryMeasurementResultValueMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            MethodMapper = new ChemistryMethodMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            MethodMapper.SetBackingStore(new List<Method>());

            OrganizationMapper = new ChemistryOrganizationMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            OrganizationMapper.SetBackingStore(new List<Organization>());

            PersonMapper = new PersonMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            PersonMapper.SetBackingStore(new List<Person>());

            ProcessingLevelMapper = new ProcessingLevelMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ProcessingLevelMapper.SetBackingStore(new List<ProcessingLevel>());

            RelatedActionMapper = new RelatedActionMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ResultMapper = new ChemistryResultMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            SamplingFeatureMapper = new ChemistrySamplingFeatureMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            SamplingFeatureMapper.SetBackingStore(new List<SamplingFeature>());

            UnitMapper = new ChemistryUnitMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            UnitMapper.SetBackingStore(new List<Unit>());

            VariableMapper = new ChemistryVariableMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            VariableMapper.SetBackingStore(new List<Variable>());

            ResultExtensionPropertyValueMapper = new ResultExtensionPropertyValueMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);

            ExtensionPropertyMapper = new ExtensionPropertyMapper(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results);
            ExtensionPropertyMapper.SetBackingStore(new List<ExtensionProperty>());
        }
    }
}
