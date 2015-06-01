using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToOrganization : ESDATConverterToODMAction
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        public ESDATConverterToOrganization(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Organization Convert(ESDATModel esdatModel, ESDATConverterToAffiliation affilicationConverter, ESDATConverterToPerson personConverter)
        {
            Organization organization = new Organization();

            const int orgCodeLength = 3;

            string labName = esdatModel.LabName;

            organization.OrganizationTypeCV = OrganizationTypeCV;
            organization.OrganizationCode = (labName.Length > orgCodeLength) ? labName.Substring(0, orgCodeLength) : labName;
            organization.OrganizationName = labName;
            organization.OrganizationDescription = null;
            organization.OrganizationLink = null;
            organization.ParentOrganizationID = null;

            //Affiliation affiliation = affilicationConverter.Convert(personConverter);
            //organization.Affiliations.Add(affiliation);

            return organization;
        }
    }
}
