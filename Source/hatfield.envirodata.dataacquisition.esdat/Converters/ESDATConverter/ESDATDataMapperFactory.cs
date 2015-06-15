using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATDataMapperFactory : IESDATDataConverterFactory
    {
        private ESDATMapper _actionByMapper;
        private ESDATMapper _actionMapper;
        private ESDATMapper _affiliationMapper;
        private ESDATMapper _DatasetMapper;
        private ESDATMapper _DatasetsResultMapper;
        private ESDATMapper _featureActionMapper;
        private ESDATMapper _measurementResultMapper;
        private ESDATMapper _measurementResultValueMapper;
        private ESDATMapper _methodMapper;
        private ESDATMapper _organizationMapper;
        private ESDATMapper _personMapper;
        private ESDATMapper _processingLevelMapper;
        private ESDATMapper _relatedActionMapper;
        private ESDATMapper _resultMapper;
        private ESDATMapper _samplingFeatureMapper;
        private ESDATMapper _unitMapper;
        private ESDATMapper _variableMapper;

        public ESDATDataMapperFactory(IDbContext dbContext, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
        {
            _actionByMapper = new ActionByMapper(dbContext, this, duplicateChecker, linker);
            _actionMapper = new ActionMapper(dbContext, this, duplicateChecker, linker);
            _affiliationMapper = new AffiliationMapper(dbContext, this, duplicateChecker, linker);
            _DatasetMapper = new DatasetMapper(dbContext, this, duplicateChecker, linker);
            _DatasetsResultMapper = new DatasetsResultMapper(dbContext, this, duplicateChecker, linker);
            _featureActionMapper = new FeatureActionMapper(dbContext, this, duplicateChecker, linker);
            _measurementResultMapper = new MeasurementResultMapper(dbContext, this, duplicateChecker, linker);
            _measurementResultValueMapper = new MeasurementResultValueMapper(dbContext, this, duplicateChecker, linker);
            _methodMapper = new MethodMapper(dbContext, this, duplicateChecker, linker);
            _organizationMapper = new OrganizationMapper(dbContext, this, duplicateChecker, linker);
            _personMapper = new PersonMapper(dbContext, this, duplicateChecker, linker);
            _processingLevelMapper = new ProcessingLevelMapper(dbContext, this, duplicateChecker, linker);
            _relatedActionMapper = new RelatedActionMapper(dbContext, this, duplicateChecker, linker);
            _resultMapper = new ResultMapper(dbContext, this, duplicateChecker, linker);
            _samplingFeatureMapper = new SamplingFeatureMapper(dbContext, this, duplicateChecker, linker);
            _unitMapper = new UnitMapper(dbContext, this, duplicateChecker, linker);
            _variableMapper = new VariableMapper(dbContext, this, duplicateChecker, linker);
        }

        public IESDATDataConverter BuildESDATMapper(Type dataType, Type odm2DomainType)
        {
            if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(ActionBy))
            {
                return _actionByMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Core.Action))
            {
                return _actionMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Affiliation))
            {
                return _affiliationMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Dataset))
            {
                return _DatasetMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(DatasetsResult))
            {
                return _DatasetsResultMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(FeatureAction))
            {
                return _featureActionMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(MeasurementResult))
            {
                return _measurementResultMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(MeasurementResultValue))
            {
                return _measurementResultValueMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Method))
            {
                return _methodMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Organization))
            {
                return _organizationMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Person))
            {
                return _personMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(ProcessingLevel))
            {
                return _processingLevelMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(RelatedAction))
            {
                return _relatedActionMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Result))
            {
                return _resultMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(SamplingFeature))
            {
                return _samplingFeatureMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Unit))
            {
                return _unitMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Variable))
            {
                return _variableMapper;
            }
            else
            {
                throw new ArgumentException(dataType + " to " + odm2DomainType + " is not a valid conversion.");
            }
        }
    }
}
