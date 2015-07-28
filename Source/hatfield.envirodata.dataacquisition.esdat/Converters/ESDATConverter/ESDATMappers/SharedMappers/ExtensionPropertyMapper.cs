using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ExtensionPropertyMapper : ExtensionPropertyMapperBase
    {
        public ExtensionPropertyMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public ExtensionProperty Map(string propertyName)
        {
            var entity = Draft(propertyName);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public ExtensionProperty Draft(string propertyName)
        {
            var entity = new ExtensionProperty();

            entity.PropertyName = propertyName;
            entity.PropertyDataTypeCV = "String";

            Validate(entity);

            return entity;
        }
    }
}
