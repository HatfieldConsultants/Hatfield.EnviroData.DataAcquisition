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
        public DatasetsResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public DatasetsResult Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            return entity;
        }

        public DatasetsResult Scaffold(ESDATModel esdatModel)
        {
            var entity = new DatasetsResult();

            return entity;
        }
    }
}
