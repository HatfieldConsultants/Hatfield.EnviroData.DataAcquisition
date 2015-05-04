using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class SimpleCSVExtractConfiguration : IExtractConfiguration
    {
        private string _propertyPath;
        private IParser _parser;
        private IValueAssigner _valueAssigner;
        private Type _propertyType;

        public SimpleCSVExtractConfiguration(string propertyPath, IParser parser, IValueAssigner valueAssigner, Type propertyType)
        {
            _propertyPath = propertyPath;
            _parser = parser;
            _valueAssigner = valueAssigner;
            _propertyType = propertyType;
        }

        public string PropertyPath
        {
            get {
                return _propertyPath;
            }
        }

        public IParser PropertyParser
        {
            get {
                return _parser;
            }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get {
                return _valueAssigner;
            }
        }
    }
}
