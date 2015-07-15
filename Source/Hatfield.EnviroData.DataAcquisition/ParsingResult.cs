using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public class ParsingResult : IParsingResult
    {
        private ResultLevel _level;
        private string _message;
        private object _value;
        private IDataSourceLocation _dataSourceLocation;

        public ParsingResult(ResultLevel level, string message, object value, IDataSourceLocation dataSourceLocation)
        {
            _level = level;
            _message = message;
            _value = value;
            _dataSourceLocation = dataSourceLocation;
        }

        public object Value
        {
            get
            {
                return _value;
            }
        }

        public ResultLevel Level
        {
            get
            {
                return _level;
            }
        }

        public virtual string Message
        {
            get
            {
                return _message;
            }
        }

        public IDataSourceLocation DataSourceLocation
        {
            get
            {
                return _dataSourceLocation;
            }
        }
    }
}