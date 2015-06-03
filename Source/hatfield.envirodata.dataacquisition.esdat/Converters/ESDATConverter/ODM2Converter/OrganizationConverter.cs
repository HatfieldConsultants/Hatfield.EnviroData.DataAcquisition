using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class OrganizationConverter : ODM2ConverterBase
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        public OrganizationConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public Organization Convert(ESDATModel esdatModel, IESDATDataConverterFactory converterFactory)
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

            var affilicationConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(Affiliation)) as AffiliationConverter;
            Affiliation affiliation = affilicationConverter.Convert(organization, converterFactory);
            organization.Affiliations.Add(affiliation);

            return organization;
        }
    }
}
