using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class AffiliationMapper : ESDATMapper
    {
        PersonMapper _personMapper;

        public AffiliationMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
            _personMapper = factory.BuildESDATMapper(typeof(ESDATModel), typeof(Person)) as PersonMapper;
        }

        public Affiliation Map(ActionBy actionBy)
        {
            var entity = Scaffold(actionBy);

            var person = _personMapper.Map();
            _linker.Link(entity, person);

            return entity;
        }

        public Affiliation Map(Organization organization)
        {
            var entity = Scaffold(organization);

            var person = _personMapper.Map();
            _linker.Link(entity, person);

            return entity;
        }

        public Affiliation Scaffold(ActionBy actionBy)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;

            return affiliation;
        }

        public Affiliation Scaffold(Organization organization)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;

            return affiliation;
        }

        public Affiliation GetDuplicate(Affiliation entity)
        {
            return GetDuplicate(entity, x =>
                x.OrganizationID.Equals(entity.OrganizationID)
            );
        }
    }
}
