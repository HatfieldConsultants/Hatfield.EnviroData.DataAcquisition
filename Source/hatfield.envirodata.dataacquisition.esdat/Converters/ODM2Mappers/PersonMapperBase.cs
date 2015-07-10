using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class PersonMapperBase : ESDATMapperBase<Person>, IODM2DuplicableMapper<Person>
    {
        public PersonMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Person GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, Person entity)
        {
            return duplicateChecker.GetDuplicate<Person>(entity, x =>
                x.PersonFirstName.Equals(entity.PersonFirstName) &&
                x.PersonMiddleName.Equals(entity.PersonMiddleName) &&
                x.PersonLastName.Equals(entity.PersonLastName),
                wayToHandleNewData
            );
        }
    }
}
