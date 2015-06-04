using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.JSON
{
    public class SimpleJSONExtractConfiguration : SimpleExtractConfigurationBase, ISimpleExtractConfiguration
    {
        private Type _propertyType;
        private string _jsonPath;

        public SimpleJSONExtractConfiguration(string jsonPath, string propertyPath, IParser parser, IValueAssigner valueAssigner, Type propertyType)
            : base(propertyPath, parser, valueAssigner)
        {
            _jsonPath = jsonPath;
            _propertyPath = propertyPath;
            _parser = parser;
            _valueAssigner = valueAssigner;
            _propertyType = propertyType;
        }

        public override IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport, IDataSourceLocation currentLocation)
        {
            if(!(dataToImport is JSONDataToImport))
            {
                throw new ArgumentException("The SimpleJSONExtractConfiguration only accept JSONDataToImport to extract data");
            }

            if (!(currentLocation is JSONDataSourceLocation))
            {
                throw new ArgumentException("The SimpleJSONExtractConfiguration only accept JSONDataSourceLocation to extract data");
            }

            throw new NotImplementedException();
        }

    }
}
