using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    /// <summary>
    /// Contains converter parameters
    /// Each mapper base is an implementor (bridge design pattern)
    /// </summary>
    public abstract class ODM2MapperSingletonFactory
    {
        public ActionByMapperBase ActionByMapper { get; protected set; }
        public ActionMapperBase ActionMapper { get; protected set; }
        public AffiliationMapperBase AffiliationMapper { get; protected set; }
        public DatasetMapperBase DatasetMapper { get; protected set; }
        public DatasetsResultMapperBase DatasetsResultMapper { get; protected set; }
        public FeatureActionMapperBase FeatureActionMapper { get; protected set; }
        public MeasurementResultMapperBase MeasurementResultMapper { get; protected set; }
        public MeasurementResultValueMapperBase MeasurementResultValueMapper { get; protected set; }
        public MethodMapperBase MethodMapper { get; protected set; }
        public OrganizationMapperBase OrganizationMapper { get; protected set; }
        public PersonMapperBase PersonMapper { get; protected set; }
        public ProcessingLevelMapperBase ProcessingLevelMapper { get; protected set; }
        public RelatedActionMapperBase RelatedActionMapper { get; protected set; }
        public ResultMapperBase ResultMapper { get; protected set; }
        public SamplingFeatureMapperBase SamplingFeatureMapper { get; protected set; }
        public UnitMapperBase UnitMapper { get; protected set; }
        public VariableMapperBase VariableMapper { get; protected set; }
    }
}
