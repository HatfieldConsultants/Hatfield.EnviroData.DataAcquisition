using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class PersonMapper : PersonMapperBase, IESDATSharedMapper<Person>
    {
        public PersonMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Person Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Person Draft(ESDATModel esdatModel)
        {
            var entity = new Person();

            entity.PersonFirstName = _WQDefaultValueProvider.DefaultPersonFirstName;
            entity.PersonMiddleName = _WQDefaultValueProvider.DefaultPersonMiddleName;
            entity.PersonLastName = _WQDefaultValueProvider.DefaultPersonLastName;

            Validate(entity);

            return entity;
        }
    }
}
