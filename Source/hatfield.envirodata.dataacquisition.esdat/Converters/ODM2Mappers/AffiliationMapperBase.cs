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
        public AffiliationMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Affiliation GetDuplicate(ESDATDuplicateChecker duplicateChecker, WayToHandleNewData wayToHandleNewData, Affiliation entity)
        {
            return duplicateChecker.GetDuplicate<Affiliation>(entity, x =>
                x.AffiliationID.Equals(entity.AffiliationID),
                wayToHandleNewData
            );
        }
    }
}
