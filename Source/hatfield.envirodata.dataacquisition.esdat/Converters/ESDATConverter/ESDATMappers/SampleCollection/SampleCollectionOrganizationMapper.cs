using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionOrganizationMapper : OrganizationMapperBase, IESDATSampleCollectionMapper<Organization>
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        public SampleCollectionOrganizationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Organization Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Organization Scaffold(ESDATModel esdatModel)
        {
            Organization organization = new Organization();

            var organizationName = "Hatfield";

            organization.OrganizationTypeCV = OrganizationTypeCV;
            organization.OrganizationCode = GetOrganizationCode(organizationName);
            organization.OrganizationName = organizationName;
            organization.OrganizationDescription = null;
            organization.OrganizationLink = null;
            organization.ParentOrganizationID = null;

            return organization;
        }
    }
}
