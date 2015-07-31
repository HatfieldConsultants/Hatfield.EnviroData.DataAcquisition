using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class DatasetMapperBase : ODM2MapperBase<Dataset>, IODM2DuplicableMapper<Dataset>
    {
        public List<Dataset> BackingStore { get; set; }

        public DatasetMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Dataset entity)
        {
            Validate(entity.DatasetTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTypeCV)));
            Validate(entity.DatasetUUID, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetUUID)));
            Validate(entity.DatasetCode, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetCode)));
            Validate(entity.DatasetTitle, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTitle)));
            Validate(entity.DatasetAbstract, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetAbstract)));
        }

        public Dataset GetDuplicate(WayToHandleNewData wayToHandleNewData, Dataset entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Dataset>(entity, x =>
                x.DatasetTypeCV.Equals(entity.DatasetTypeCV) &&
                x.DatasetUUID.Equals(entity.DatasetUUID) &&
                x.DatasetCode.Equals(entity.DatasetCode) &&
                x.DatasetTitle.Equals(entity.DatasetTitle),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }
    }
}
