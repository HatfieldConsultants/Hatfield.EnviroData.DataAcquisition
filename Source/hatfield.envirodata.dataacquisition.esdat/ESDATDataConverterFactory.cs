using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.DataAcquisition.ESDAT.Converters;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATDataConverterFactory : IESDATDataConverterFactory
    {
        private IDbContext _dbContext;

        public ESDATDataConverterFactory(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IESDATDataConverter BuildDataConverter(Type dataType, Type odm2DomainType)
        {
            if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(ActionBy))
            {
                return new ActionByConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Core.Action))
            {
                return new ActionConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Affiliation))
            {
                return new AffiliationConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(DataSet))
            {
                return new DataSetConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(DataSetsResult))
            {
                return new DataSetsResultConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(FeatureAction))
            {
                return new FeatureActionConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(MeasurementResult))
            {
                return new MeasurementResultConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(MeasurementResultValue))
            {
                return new MeasurementResultValueConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Method))
            {
                return new MethodConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Organization))
            {
                return new OrganizationConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Person))
            {
                return new PersonConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(ProcessingLevel))
            {
                return new ProcessingLevelConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(RelatedAction))
            {
                return new RelatedActionConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Result))
            {
                return new ResultConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(SamplingFeature))
            {
                return new SamplingFeatureConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Unit))
            {
                return new UnitConverter(_dbContext);
            }
            else if (dataType == typeof(ESDATModel) && odm2DomainType == typeof(Variable))
            {
                return new VariableConverter(_dbContext);
            }
            else
            {
                return null;
            }
        }
    }
}
