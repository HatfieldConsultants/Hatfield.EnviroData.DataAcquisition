using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class PersonMapper : PersonMapperBase
    {
        protected ESDATMapperParametersBase _parameters;

        public PersonMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override Person Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Person Scaffold()
        {
            Person person = new Person();

            person.PersonFirstName = string.Empty;
            person.PersonMiddleName = string.Empty;
            person.PersonLastName = string.Empty;

            return person;
        }
    }
}
