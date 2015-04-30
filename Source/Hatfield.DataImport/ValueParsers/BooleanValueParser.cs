using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.ValueParsers
{
    public class BooleanValueParser:IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot parse null value to Boolean");
            }
            else
            {
                try
                {
                    return Convert.ToBoolean(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Cannot parse value ( "+value+" ) to Boolean");
                }
            }
        }
    }
}
