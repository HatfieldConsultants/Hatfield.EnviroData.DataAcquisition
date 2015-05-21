using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public abstract class SimpleExtractConfigurationBase : ISimpleExtractConfiguration
    {
        protected string _propertyPath;
        protected IParser _parser;
        protected IValueAssigner _valueAssigner;

        public SimpleExtractConfigurationBase(string propertyPath, IParser parser, IValueAssigner valueAssigner)
        {
            _propertyPath = propertyPath;
            _parser = parser;
            _valueAssigner = valueAssigner;
        }

        public IParser PropertyParser
        {
            get { return _parser; }
        }

        public abstract IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport,
                                                         IDataSourceLocation currentLocation);
        

        public string PropertyPath
        {
            get { return _propertyPath; }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get { return _valueAssigner; }
        }
    }
}
