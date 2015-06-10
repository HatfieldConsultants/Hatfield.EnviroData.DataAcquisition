using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ValueParsers
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
                return Convert.ToString(value).Trim();
            }
        }
    }
}
