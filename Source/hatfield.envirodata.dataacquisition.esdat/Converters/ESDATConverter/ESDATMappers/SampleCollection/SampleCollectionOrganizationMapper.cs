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
        public SampleCollectionOrganizationMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Organization Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            LogMappingComplete(this);

            return entity;
        }

        public Organization Scaffold(ESDATModel esdatModel)
        {
            Organization organization = new Organization();

            organization.OrganizationTypeCV = _WQDefaultValueProvider.OrganizationTypeCVSampleCollection;
            organization.OrganizationCode = GetOrganizationCode(_WQDefaultValueProvider.OrganizationNameSampleCollection);
            organization.OrganizationName = _WQDefaultValueProvider.OrganizationNameSampleCollection;
            organization.OrganizationDescription = null;
            organization.OrganizationLink = null;
            organization.ParentOrganizationID = null;

            LogScaffoldingComplete(this);

            return organization;
        }
    }
}
