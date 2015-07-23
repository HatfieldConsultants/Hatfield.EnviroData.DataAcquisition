using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionOrganizationMapper : OrganizationMapperBase, IESDATSampleCollectionMapper<Organization>
    {
        public SampleCollectionOrganizationMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Organization Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Organization Draft(ESDATModel esdatModel)
        {
            var entity = new Organization();

            entity.OrganizationTypeCV = _WQDefaultValueProvider.OrganizationTypeCVSampleCollection;
            entity.OrganizationCode = GetOrganizationCode(_WQDefaultValueProvider.OrganizationNameSampleCollection);
            entity.OrganizationName = _WQDefaultValueProvider.OrganizationNameSampleCollection;

            Validate(entity);

            return entity;
        }
    }
}
