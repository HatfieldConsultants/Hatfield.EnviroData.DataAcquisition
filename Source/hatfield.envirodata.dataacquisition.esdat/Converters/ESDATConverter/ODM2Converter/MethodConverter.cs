using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MethodConverter : ODM2ConverterBase
    {
        // Sample Collection Constants
        private const string MethodTypeCVSampleCollection = "fieldActivity";
        private const string MethodNameSampleCollection = "Sample Collection";

        // Chemistry Constants
        private const string MethodTypeCVChemistry = "specimenAnalysis";

        public MethodConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Method Convert(ESDATModel esdatModel, IESDATDataConverterFactory converterFactory)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            var organizationConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Organization)) as OrganizationConverter;
            //method.Organization = organizationConverter.Convert(converterFactory);

            return method;
        }

        public Method Convert(ChemistryFileData chemistry, IESDATDataConverterFactory converterFactory)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            var organizationConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Organization)) as OrganizationConverter;
            //method.Organization = organizationConverter.Convert(converterFactory);

            return method;
        }
    }
}
