using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public class ParsingResult : IParsingResult
    {
        private ResultLevel _level;
        private string _message;
        private object _value;
        
        public ParsingResult(ResultLevel level, string message, object value)
        {
            _level = level;
            _message = message;
            _value = value;
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
    }
}
