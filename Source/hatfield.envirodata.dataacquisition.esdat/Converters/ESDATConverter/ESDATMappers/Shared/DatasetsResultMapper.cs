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
        public DatasetsResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public DatasetsResult Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            LogMappingComplete(this);

            return entity;
        }

        public DatasetsResult Scaffold(ESDATModel esdatModel)
        {
            var entity = new DatasetsResult();

            LogScaffoldingComplete(this);

            return entity;
        }
    }
}
