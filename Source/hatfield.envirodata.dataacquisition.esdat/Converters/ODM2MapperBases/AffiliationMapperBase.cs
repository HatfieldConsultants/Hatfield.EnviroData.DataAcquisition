using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class AffiliationMapperBase : ODM2MapperBase<Affiliation>, IODM2DuplicableMapper<Affiliation>
    {
        List<Affiliation> _backingStore;

        public AffiliationMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Affiliation> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Affiliation entity)
        {
            Validate(entity.AffiliationStartDate, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.AffiliationStartDate)));
            Validate(entity.PrimaryEmail, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PrimaryEmail)));
        }

        public Affiliation GetDuplicate(WayToHandleNewData wayToHandleNewData, Affiliation entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Affiliation>(entity, x =>
                x.Person.PersonFirstName.Equals(entity.Person.PersonFirstName) &&
                x.Person.PersonMiddleName.Equals(entity.Person.PersonMiddleName) &&
                x.Person.PersonLastName.Equals(entity.Person.PersonLastName),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
