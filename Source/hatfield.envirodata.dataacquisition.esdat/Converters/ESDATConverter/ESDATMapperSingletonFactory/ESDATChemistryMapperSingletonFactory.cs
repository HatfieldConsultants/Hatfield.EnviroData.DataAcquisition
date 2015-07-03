using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATChemistryMapperSingletonFactory : ESDATMapperSingletonFactoryBase
    {
        public ESDATChemistryMapperSingletonFactory(ESDATChemistryParameters parameters)
        {
            ActionByMapper = new ActionByMapper(parameters);
            ActionMapper = new ChemistryActionMapper(this, parameters);
            AffiliationMapper = new AffiliationMapper(parameters);
            DatasetMapper = new DatasetMapper(parameters);
            DatasetsResultMapper = new DatasetsResultMapper(parameters);
            FeatureActionMapper = new ChemistryFeatureActionMapper(parameters);
            MeasurementResultMapper = new ChemistryMeasurementResultMapper(parameters);
            MeasurementResultValueMapper = new ChemistryMeasurementResultValueMapper(parameters);
            MethodMapper = new ChemistryMethodMapper(parameters);
            OrganizationMapper = new ChemistryOrganizationMapper(parameters);
            PersonMapper = new PersonMapper(parameters);
            ProcessingLevelMapper = new ProcessingLevelMapper(parameters);
            RelatedActionMapper = new RelatedActionMapper(parameters);
            ResultMapper = new ChemistryResultMapper(parameters);
            SamplingFeatureMapper = new ChemistrySamplingFeatureMapper(parameters);
            UnitMapper = new ChemistryUnitMapper(parameters);
            VariableMapper = new ChemistryVariableMapper(parameters);
        }
    }
}
