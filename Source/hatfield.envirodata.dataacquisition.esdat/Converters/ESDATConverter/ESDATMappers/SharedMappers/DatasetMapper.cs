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
        public DatasetMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Dataset Map(ESDATModel esdatModel)
        {
            var entity = Draft(esdatModel);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Dataset Draft(ESDATModel esdatModel)
        {
            var entity = new Dataset();

            entity.DatasetTypeCV = _WQDefaultValueProvider.DefaultDatasetTypeCV;
            entity.DatasetCode = esdatModel.LabRequestId.ToString();
            entity.DatasetTitle = String.Format("{0}: {1} ({2})", esdatModel.LabName, esdatModel.LabRequestId.ToString(), esdatModel.DateReported);
            entity.DatasetAbstract = string.Empty;

            Validate(entity);

            return entity;
        }
    }
}
