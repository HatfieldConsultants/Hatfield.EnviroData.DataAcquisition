using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ResultExtensionPropertyValueMapper : ResultExtensionPropertyValueMapperBase
    {
        public ResultExtensionPropertyValueMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
            : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public ResultExtensionPropertyValue Map(int propertyID, string propertyValue)
        {
            var entity = Draft(propertyID, propertyValue);

            return entity;
        }

        public ResultExtensionPropertyValue Draft(int propertyID, string propertyValue)
        {
            var entity = new ResultExtensionPropertyValue();

            entity.PropertyID = propertyID;
            entity.PropertyValue = propertyValue;

            Validate(entity);

            return entity;
        }
    }
}
