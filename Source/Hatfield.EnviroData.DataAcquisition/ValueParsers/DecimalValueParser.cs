using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ValueParsers
{
    public class DecimalValueParser: IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                return 0.0;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(value);
                }
                catch (Exception)
                {
                    throw new FormatException("Cannot parse value ( "+value+" ) to Decimal");
                }
            }
        }
    }
}
