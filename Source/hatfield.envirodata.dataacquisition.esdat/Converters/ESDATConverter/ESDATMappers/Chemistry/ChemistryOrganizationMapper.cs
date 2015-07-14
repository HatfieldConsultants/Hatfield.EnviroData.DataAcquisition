using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryOrganizationMapper : OrganizationMapperBase, IESDATChemistryMapper<Organization>
    {
        public SampleFileData SampleFileData { get; set; }

        // Constants
        private const string OrganizationTypeCV = "Laboratory";

        public ChemistryOrganizationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Organization Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Organization Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            Organization organization = new Organization();

            var organizationName = SampleFileData.LabName;

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
