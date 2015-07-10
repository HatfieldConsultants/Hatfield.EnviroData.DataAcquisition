using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class AffiliationMapper : AffiliationMapperBase, IESDATSharedMapper<Affiliation>
    {
        public AffiliationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Affiliation Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            return entity;
        }

        public Affiliation Scaffold(ESDATModel esdatModel)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Now;
            affiliation.PrimaryEmail = string.Empty;

            return affiliation;
        }
    }
}
