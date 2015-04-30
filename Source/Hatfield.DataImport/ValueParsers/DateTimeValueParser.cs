using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.ValueParsers
{
    public class DateTimeValueParser : IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Can not parse null value to datetime");
            }
            else
            {
                try
                {
                    return Convert.ToDateTime(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Can not parse value ( "+value+" ) to datetime");
                }
            }

        }
    }
}
