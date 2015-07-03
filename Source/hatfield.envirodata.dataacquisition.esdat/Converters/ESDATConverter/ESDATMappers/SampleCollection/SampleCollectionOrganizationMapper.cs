using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionOrganizationMapper : OrganizationMapperBase
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionOrganizationMapper(ESDATSampleCollectionParameters parameters)
        {
            _parameters = parameters;
        }

        public override Organization Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Organization Scaffold()
        {
            Organization organization = new Organization();

            var esdatModel = _parameters.EsdatModel;

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
