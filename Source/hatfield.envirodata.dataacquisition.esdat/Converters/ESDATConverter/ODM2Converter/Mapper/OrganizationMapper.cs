using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class OrganizationMapper : ODM2MapperQueryable
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        public OrganizationMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Organization Map(ESDATModel esdatModel, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(esdatModel);
            entity = this.CheckDuplicate(entity);

            var affiliationMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Affiliation)) as AffiliationMapper;
            var affiliation = affiliationMapper.Map(entity, factory);

            return this.Link(entity, affiliation);
        }

        public Organization Scaffold(ESDATModel esdatModel)
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

            return organization;
        }

        public Organization CheckDuplicate(Organization entity)
        {
            return this.GetDbMatch(entity, x =>
                x.OrganizationName.Equals(entity.OrganizationName)
            );
        }

        public Organization Link(Organization entity, Affiliation affiliation)
        {
            entity.Affiliations.Add(affiliation);

            return entity;
        }
    }
}
