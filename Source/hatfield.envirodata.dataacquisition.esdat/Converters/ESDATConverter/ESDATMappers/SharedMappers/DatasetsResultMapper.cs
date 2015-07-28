using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetsResultMapper : DatasetsResultMapperBase, IESDATSharedMapper<DatasetsResult>
    {
        public DatasetsResultMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public DatasetsResult Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);

            return entity;
        }

        public DatasetsResult Draft(ESDATModel esdatModel)
        {
            var entity = new DatasetsResult();

            Validate(entity);

            return entity;
        }
    }
}
