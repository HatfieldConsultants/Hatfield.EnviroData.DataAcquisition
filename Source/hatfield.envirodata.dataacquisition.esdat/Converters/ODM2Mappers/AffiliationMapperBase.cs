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

        public AffiliationMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public void SetBackingStore(List<Affiliation> backingStore)
        {
            _backingStore = backingStore;
        }

        public Affiliation GetDuplicate(WayToHandleNewData wayToHandleNewData, Affiliation entity)
        {
            return _duplicateChecker.GetDuplicate<Affiliation>(entity, x =>
                x.PrimaryAddress.Equals(entity.PrimaryAddress),
                wayToHandleNewData,
                _backingStore
            );
        }
    }
}
