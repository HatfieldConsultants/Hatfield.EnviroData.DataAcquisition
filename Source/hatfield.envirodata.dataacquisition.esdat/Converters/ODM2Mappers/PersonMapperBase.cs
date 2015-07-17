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
        List<Person> _backingStore;

        public PersonMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Person> backingStore)
        {
            _backingStore = backingStore;
        }

        public Person GetDuplicate(WayToHandleNewData wayToHandleNewData, Person entity)
        {
            var duplicate = entity;

            try
            {
                duplicate = _duplicateChecker.GetDuplicate<Person>(entity, x =>
                    x.PersonFirstName.Equals(entity.PersonFirstName) &&
                    x.PersonMiddleName.Equals(entity.PersonMiddleName) &&
                    x.PersonLastName.Equals(entity.PersonLastName),
                    wayToHandleNewData,
                    _backingStore
                );
            }
            catch (KeyNotFoundException)
            {
                var location = new MapperSourceLocation(this.ToString(), null);
                LogNotFoundInDatabaseException(location);
            }

            return duplicate;
        }
    }
}
