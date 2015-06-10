using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MethodMapper : ODM2MapperQueryable
    {
        // Sample Collection Constants
        private const string MethodTypeCVSampleCollection = "fieldActivity";
        private const string MethodNameSampleCollection = "Sample Collection";

        // Chemistry Constants
        private const string MethodTypeCVChemistry = "specimenAnalysis";

        public MethodMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Method Map(ESDATModel esdatModel, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(esdatModel);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, null);
        }

        public Method Map(ChemistryFileData chemistry, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(chemistry);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, null);
        }

        public Method Scaffold(ESDATModel esdatModel)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            return method;
        }

        public Method Scaffold(ChemistryFileData chemistry)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVChemistry;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            return method;
        }

        public Method CheckDuplicate(Method entity)
        {
            return this.GetDbMatch(entity, x =>
                x.MethodTypeCV.Equals(entity.MethodTypeCV) &&
                x.MethodName.Equals(entity.MethodName)
            );
        }

        public Method Link(Method entity, Organization organization)
        {
            if (organization != null)
            {
                entity.Organization = organization;
                entity.OrganizationID = organization.OrganizationID;
            }

            return entity;
        }
    }
}
