using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class MethodConverter : ODM2ActionConverter
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

        public Method Convert(ESDATModel model, OrganizationConverter organizationConverter, AffiliationConverter affiliationConverter, PersonConverter personConverter)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            //method.Organization = organizationConverter.Convert(affiliationConverter, personConverter);

            return method;
        }

        public Method Convert(ChemistryFileData chemistry, OrganizationConverter organizationConverter, AffiliationConverter affiliationConverter, PersonConverter personConverter)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            //method.Organization = organizationConverter.Convert(affiliationConverter, personConverter);

            return method;
        }
    }
}
