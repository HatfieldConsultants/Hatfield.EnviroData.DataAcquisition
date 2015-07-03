using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class AffiliationMapperBase : IODM2DuplicableMapper<Affiliation>
    {
        public abstract Affiliation Scaffold();
        public abstract Affiliation Map();

        public Affiliation GetDuplicate(ODM2DuplicateChecker duplicateChecker, Affiliation entity)
        {
            return duplicateChecker.GetDuplicate<Affiliation>(entity, x =>
                x.AffiliationID.Equals(entity.AffiliationID)
            );
        }
    }
}
