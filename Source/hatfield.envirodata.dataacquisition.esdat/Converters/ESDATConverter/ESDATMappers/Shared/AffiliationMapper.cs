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
        public Person Person { get; set; }

        public AffiliationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Affiliation Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public Affiliation Scaffold(ESDATModel esdatModel)
        {
            Affiliation affiliation = new Affiliation();

            affiliation.AffiliationStartDate = DateTime.Today;
            affiliation.PrimaryEmail = string.Empty;

            ODM2EntityLinker.Link(affiliation, Person);

            LogScaffoldingComplete(this);

            return affiliation;
        }
    }
}
