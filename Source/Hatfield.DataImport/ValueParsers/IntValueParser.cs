using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.ValueParsers
{
    public class IntValueParser : IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToInt32(value);    
                }
                catch(Exception)
                {
                    throw new FormatException("Can not parse value ( "+value+" ) to integer");
                }
            }
            
        }
    }
}
