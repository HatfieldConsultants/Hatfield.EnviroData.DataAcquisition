using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.ValueParsers
{
    public class StringValueParser : IValueParser
    {
        public object Parse(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                return value.ToString().Trim();
            }
        }
    }
}
