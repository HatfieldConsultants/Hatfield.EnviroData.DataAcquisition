using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class DatasetMapperBase : ESDATMapperBase<Dataset>, IODM2DuplicableMapper<Dataset>
    {
        List<Dataset> _backingStore;

        public DatasetMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public void SetBackingStore(List<Dataset> backingStore)
        {
            _backingStore = backingStore;
        }

        protected override void Validate(Dataset entity)
        {
            Validate(entity.DatasetTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTypeCV)));
            Validate(entity.DatasetCode, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetCode)));
            Validate(entity.DatasetTitle, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTitle)));
            Validate(entity.DatasetAbstract, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetAbstract)));
        }

        public Dataset GetDuplicate(WayToHandleNewData wayToHandleNewData, Dataset entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<Dataset>(entity, x =>
                x.DatasetTypeCV.Equals(entity.DatasetTypeCV) &&
                x.DatasetCode.Equals(entity.DatasetCode) &&
                x.DatasetTitle.Equals(entity.DatasetTitle),
                wayToHandleNewData,
                _backingStore
            );

            return duplicate;
        }
    }
}
