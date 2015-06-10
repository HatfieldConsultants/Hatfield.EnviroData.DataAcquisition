using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class PersonMapper : ODM2MapperQueryable
    {
        public PersonMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public Person Map(Affiliation affiliation)
        {
            var entity = this.Scaffold(affiliation);
            entity = this.CheckDuplicate(entity);

            return this.Link(entity, affiliation);
        }

        public Person Scaffold(Affiliation affiliation)
        {
            Person person = new Person();

            person.PersonFirstName = string.Empty;
            person.PersonLastName = string.Empty;

            return person;
        }

        public Person CheckDuplicate(Person entity)
        {
            return this.GetDbMatch(entity, x =>
                x.PersonFirstName.Equals(entity.PersonFirstName) &&
                x.PersonLastName.Equals(entity.PersonLastName)
            );
        }

        public Person Link(Person entity, Affiliation affiliation)
        {
            entity.Affiliations.Add(affiliation);

            return entity;
        }
    }
}
