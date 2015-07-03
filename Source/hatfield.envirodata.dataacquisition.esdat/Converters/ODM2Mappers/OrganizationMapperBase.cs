using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class OrganizationMapperBase : IODM2DuplicableMapper<Organization>
    {
        public abstract Organization Scaffold();
        public abstract Organization Map();

        public Organization GetDuplicate(ODM2DuplicateChecker duplicateChecker, Organization entity)
        {
            return duplicateChecker.GetDuplicate<Organization>(entity, x =>
                x.OrganizationTypeCV.Equals(entity.OrganizationTypeCV) &&
                x.OrganizationCode.Equals(entity.OrganizationCode) &&
                x.OrganizationName.Equals(entity.OrganizationName)
            );
        }
        protected string GetOrganizationCode(string organizationName)
        {
            const int orgCodeLength = 3;
            return (organizationName.Length > orgCodeLength) ? organizationName.Substring(0, orgCodeLength) : organizationName;
        }
    }
}
