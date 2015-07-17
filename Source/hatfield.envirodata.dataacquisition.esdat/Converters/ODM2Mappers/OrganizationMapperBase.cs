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
        List<Organization> _backingStore;

        public OrganizationMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Organization> backingStore)
        {
            _backingStore = backingStore;
        }

        public Organization GetDuplicate(WayToHandleNewData wayToHandleNewData, Organization entity)
        {
            var duplicate = entity;

            try
            {
                duplicate = _duplicateChecker.GetDuplicate<Organization>(entity, x =>
                    x.OrganizationTypeCV.Equals(entity.OrganizationTypeCV) &&
                    x.OrganizationCode.Equals(entity.OrganizationCode) &&
                    x.OrganizationName.Equals(entity.OrganizationName),
                    wayToHandleNewData,
                    _backingStore
                );
            }
            catch (KeyNotFoundException)
            {
                var location = new MapperSourceLocation(this.ToString(), null);
                LogNotFoundInDatabaseException(location);
            }

            return duplicate;
        }

        protected string GetOrganizationCode(string organizationName)
        {
            const int orgCodeLength = 3;
            return (organizationName.Length > orgCodeLength) ? organizationName.Substring(0, orgCodeLength) : organizationName;
        }
    }
}
