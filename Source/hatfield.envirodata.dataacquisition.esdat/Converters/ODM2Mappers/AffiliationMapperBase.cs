using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class AffiliationMapperBase : ESDATMapperBase<Affiliation>, IODM2DuplicableMapper<Affiliation>
    {
        List<Affiliation> _backingStore;

        public AffiliationMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Affiliation> backingStore)
        {
            _backingStore = backingStore;
        }

        public Affiliation GetDuplicate(WayToHandleNewData wayToHandleNewData, Affiliation entity)
        {
            var duplicate = entity;

            try
            {
                duplicate = _duplicateChecker.GetDuplicate<Affiliation>(entity,
                    x => x.Person.PersonFirstName.Equals(entity.Person.PersonFirstName),
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
