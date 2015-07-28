using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class OrganizationMapperBase : ODM2MapperBase<Organization>, IODM2DuplicableMapper<Organization>
    {
        List<Organization> _backingStore;

        public OrganizationMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Organization> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Organization entity)
        {
            Validate(entity.OrganizationTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.OrganizationTypeCV)));
            Validate(entity.OrganizationCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.OrganizationCode)));
            Validate(entity.OrganizationName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.OrganizationName)));
        }

        public Organization GetDuplicate(WayToHandleNewData wayToHandleNewData, Organization entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Organization>(entity, x =>
                x.OrganizationTypeCV.Equals(entity.OrganizationTypeCV) &&
                x.OrganizationCode.Equals(entity.OrganizationCode) &&
                x.OrganizationName.Equals(entity.OrganizationName),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }

        protected string GetOrganizationCode(string organizationName)
        {
            const int orgCodeLength = 3;
            return (organizationName.Length > orgCodeLength) ? organizationName.Substring(0, orgCodeLength) : organizationName;
        }
    }
}
