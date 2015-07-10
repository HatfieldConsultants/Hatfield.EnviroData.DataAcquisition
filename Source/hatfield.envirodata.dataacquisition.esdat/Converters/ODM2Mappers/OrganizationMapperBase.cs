using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class OrganizationMapperBase : ESDATMapperBase<Organization>, IODM2DuplicableMapper<Organization>
    {
        public OrganizationMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Organization GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, Organization entity)
        {
            return duplicateChecker.GetDuplicate<Organization>(entity, x =>
                x.OrganizationTypeCV.Equals(entity.OrganizationTypeCV) &&
                x.OrganizationCode.Equals(entity.OrganizationCode) &&
                x.OrganizationName.Equals(entity.OrganizationName),
                wayToHandleNewData
            );
        }
        protected string GetOrganizationCode(string organizationName)
        {
            const int orgCodeLength = 3;
            return (organizationName.Length > orgCodeLength) ? organizationName.Substring(0, orgCodeLength) : organizationName;
        }
    }
}
