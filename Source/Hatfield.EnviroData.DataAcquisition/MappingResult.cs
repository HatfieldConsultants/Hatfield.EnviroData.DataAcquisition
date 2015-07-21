using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public class MappingResult : IResult
    {
        private ResultLevel _level;
        private string _message;
        private IDataSourceLocation _dataSourceLocation;

        public MappingResult(ResultLevel level, string message, IDataSourceLocation dataSourceLocation)
        {
            _level = level;
            _message = message;
            _dataSourceLocation = dataSourceLocation;
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