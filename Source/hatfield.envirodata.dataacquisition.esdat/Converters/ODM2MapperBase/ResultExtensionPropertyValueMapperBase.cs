using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ResultExtensionPropertyValueMapperBase : ESDATMapperBase<ResultExtensionPropertyValue>
    {
        public ResultExtensionPropertyValueMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(ResultExtensionPropertyValue entity)
        {
            Validate(entity.PropertyID, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.PropertyID)));
            Validate(entity.PropertyValue, new MapperSourceLocation(this.ToString(), GetVariableName(() => entity.PropertyValue)));
        }
    }
}
