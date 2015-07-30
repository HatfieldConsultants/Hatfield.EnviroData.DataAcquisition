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

        public AffiliationMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Affiliation Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Affiliation Draft(ESDATModel esdatModel)
        {
            var entity = new Affiliation();

            entity.AffiliationStartDate = DateTime.Today;
            entity.PrimaryEmail = string.Empty;

            ODM2EntityLinker.Link(entity, Person);

            Validate(entity);

            return entity;
        }
    }
}
