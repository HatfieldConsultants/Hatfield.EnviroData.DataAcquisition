using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class DatasetMapperBase : ESDATMapperBase<Dataset>
    {
        public DatasetMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(Dataset entity)
        {
            Validate(entity.DatasetTypeCV, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTypeCV)));
            Validate(entity.DatasetCode, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetCode)));
            Validate(entity.DatasetTitle, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetTitle)));
            Validate(entity.DatasetAbstract, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.DatasetAbstract)));
        }
    }
}
