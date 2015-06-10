using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATDataMapperFactory : IESDATDataConverterFactory
    {
        private ODM2MapperBase _actionByMapper;
        private ODM2MapperBase _actionMapper;
        private ODM2MapperBase _affiliationMapper;
        private ODM2MapperBase _dataSetMapper;
        private ODM2MapperBase _dataSetsResultMapper;
        private ODM2MapperBase _featureActionMapper;
        private ODM2MapperBase _measurementResultMapper;
        private ODM2MapperBase _measurementResultValueMapper;
        private ODM2MapperBase _methodMapper;
        private ODM2MapperBase _organizationMapper;
        private ODM2MapperBase _personMapper;
        private ODM2MapperBase _processingLevelMapper;
        private ODM2MapperBase _relatedActionMapper;
        private ODM2MapperBase _resultMapper;
        private ODM2MapperBase _samplingFeatureMapper;
        private ODM2MapperBase _unitMapper;
        private ODM2MapperBase _variableMapper;

        public ESDATDataMapperFactory(IDbContext dbContext, DuplicateChecker duplicateChecker)
        {
            _actionByMapper = new ActionByMapper(dbContext, duplicateChecker);
            _actionMapper = new ActionMapper(dbContext, duplicateChecker);
            _affiliationMapper = new AffiliationMapper(dbContext, duplicateChecker);
            _dataSetMapper = new DatasetMapper(dbContext, duplicateChecker);
            _dataSetsResultMapper = new DataSetsResultMapper(dbContext, duplicateChecker);
            _featureActionMapper = new FeatureActionMapper(dbContext, duplicateChecker);
            _measurementResultMapper = new MeasurementResultMapper(dbContext, duplicateChecker);
            _measurementResultValueMapper = new MeasurementResultValueMapper(dbContext, duplicateChecker);
            _methodMapper = new MethodMapper(dbContext, duplicateChecker);
            _organizationMapper = new OrganizationMapper(dbContext, duplicateChecker);
            _personMapper = new PersonMapper(dbContext, duplicateChecker);
            _processingLevelMapper = new ProcessingLevelMapper(dbContext, duplicateChecker);
            _relatedActionMapper = new RelatedActionMapper(dbContext, duplicateChecker);
            _resultMapper = new ResultMapper(dbContext, duplicateChecker);
            _samplingFeatureMapper = new SamplingFeatureMapper(dbContext, duplicateChecker);
            _unitMapper = new UnitMapper(dbContext, duplicateChecker);
            _variableMapper = new VariableMapper(dbContext, duplicateChecker);
        }

        public IESDATDataConverter BuildDataConverter(Type dataType, Type odm2DomainType)
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
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(DataSet))
            {
                return _dataSetMapper;
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(DataSetsResult))
            {
                return _dataSetsResultMapper;
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
