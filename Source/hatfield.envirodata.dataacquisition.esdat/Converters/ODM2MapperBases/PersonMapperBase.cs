using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class PersonMapperBase : ODM2MapperBase<Person>, IODM2DuplicableMapper<Person>
    {
        List<Person> _backingStore;

        public PersonMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Person> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Person entity)
        {
            Validate(entity.PersonFirstName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PersonFirstName)));
            Validate(entity.PersonMiddleName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PersonMiddleName)));
            Validate(entity.PersonLastName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PersonLastName)));
        }

        public Person GetDuplicate(WayToHandleNewData wayToHandleNewData, Person entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Person>(entity, x =>
                x.PersonFirstName.Equals(entity.PersonFirstName) &&
                x.PersonMiddleName.Equals(entity.PersonMiddleName) &&
                x.PersonLastName.Equals(entity.PersonLastName),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
