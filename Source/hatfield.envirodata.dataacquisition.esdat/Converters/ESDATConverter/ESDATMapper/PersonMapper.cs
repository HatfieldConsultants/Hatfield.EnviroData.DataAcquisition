using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class PersonMapper : ESDATMapper
    {
        public PersonMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
            : base(dbContext, factory, duplicateChecker, linker)
        {
        }

        public Person Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(entity);

            return entity;
        }

        public Person Scaffold()
        {
            Person person = new Person();

            person.PersonFirstName = string.Empty;
            person.PersonLastName = string.Empty;

            return person;
        }

        public Person GetDuplicate(Person entity)
        {
            return GetDuplicate(entity, x =>
                x.PersonFirstName.Equals(entity.PersonFirstName) &&
                x.PersonLastName.Equals(entity.PersonLastName)
            );
        }
    }
}
