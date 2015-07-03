using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class PersonMapperBase : IODM2DuplicableMapper<Person>
    {
        public abstract Person Scaffold();
        public abstract Person Map();

        public Person GetDuplicate(ODM2DuplicateChecker duplicateChecker, Person entity)
        {
            return duplicateChecker.GetDuplicate<Person>(entity, x =>
                x.PersonFirstName.Equals(entity.PersonFirstName) &&
                x.PersonMiddleName.Equals(entity.PersonMiddleName) &&
                x.PersonLastName.Equals(entity.PersonLastName)
            );
        }
    }
}
