using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class OrganizationMapper : ESDATMapper
    {
        // Constants
        private const string OrganizationTypeCV = "Company";

        // Mappers
        AffiliationMapper _affiliationMapper;

        public OrganizationMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _affiliationMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Affiliation)) as AffiliationMapper;
        }

        public Organization Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(entity);

            var affiliation = _affiliationMapper.Map(entity);
            _linker.Link(entity, affiliation);

            return entity;
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

        public Organization GetDuplicate(Organization entity)
        {
            return GetDuplicate(entity, x =>
                x.OrganizationName.Equals(entity.OrganizationName)
            );
        }
    }
}
