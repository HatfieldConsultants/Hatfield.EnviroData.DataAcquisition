using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ExtensionPropertyMapperBase : ODM2MapperBase<ExtensionProperty>, IODM2DuplicableMapper<ExtensionProperty>
    {
        public List<ExtensionProperty> BackingStore { get; set; }

        public ExtensionPropertyMapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        protected override void Validate(ExtensionProperty entity)
        {
            Validate(entity.PropertyName, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PropertyName)));
            Validate(entity.PropertyDataTypeCV, new ODM2ConverterSourceLocation(this.ToString(), GetVariableName(() => entity.PropertyDataTypeCV)));
        }

        public ExtensionProperty GetDuplicate(WayToHandleNewData wayToHandleNewData, ExtensionProperty entity)
        {
            var duplicate = entity;

            duplicate = _duplicateChecker.GetDuplicate<ExtensionProperty>(
                entity, x => x.PropertyName.Equals(entity.PropertyName),
                wayToHandleNewData,
                BackingStore
            );

            return duplicate;
        }
    }
}
