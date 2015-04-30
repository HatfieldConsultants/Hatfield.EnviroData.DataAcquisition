using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public class BaseResult : IResult
    {
        private ResultLevel _level;
        private string _message;

        public BaseResult(ResultLevel level, string message)
        {
            _level = level;
            _message = message;            
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
