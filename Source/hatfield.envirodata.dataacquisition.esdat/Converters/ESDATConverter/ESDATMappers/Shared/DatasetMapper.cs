using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetMapper : DatasetMapperBase, IESDATSharedMapper<Dataset>
    {
        public DatasetMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Dataset Map(ESDATModel esdatModel)
        {
            var entity = Scaffold(esdatModel);

            LogMappingComplete(this);

            return entity;
        }

        public Dataset Scaffold(ESDATModel esdatModel)
        {
            Dataset dataset = new Dataset();

            dataset.DatasetTypeCV = _WQDefaultValueProvider.DefaultDatasetTypeCV;
            dataset.DatasetCode = string.Empty;
            dataset.DatasetTitle = string.Empty;
            dataset.DatasetAbstract = string.Empty;

            LogScaffoldingComplete(this);

            return dataset;
        }
    }
}
