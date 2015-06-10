using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class AffiliationMapper : ODM2MapperQueryable
    {
        public AffiliationMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Affiliation Map(ActionBy actionBy, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(actionBy);

            var personMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Person)) as PersonMapper;
            var person = personMapper.Map(entity);

            return this.Link(entity, person);
        }

        public Affiliation Map(Organization organization, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(organization);

            var personMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(Person)) as PersonMapper;
            var person = personMapper.Map(entity);

            return this.Link(entity, person);
        }

        public Affiliation Scaffold(ActionBy actionBy)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;
            affiliation.ActionBies.Add(actionBy);

            return affiliation;
        }

        public Affiliation Scaffold(Organization organization)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;
            affiliation.OrganizationID = organization.OrganizationID;
            affiliation.Organization = organization;

            return affiliation;
        }

        public Affiliation CheckDuplicate(Affiliation entity)
        {
            return this.GetDbMatch(entity, x =>
                x.OrganizationID.Equals(entity.OrganizationID)
            );
        }

        public Affiliation Link(Affiliation entity, Person person)
        {
            entity.Person = person;
            entity.PersonID = person.PersonID;

            return entity;
        }
    }
}
