using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ValueParsers
{
    public class NullableDecimalValueParser:IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null)
            {
                return null;
            }
            else
            {
                try
                {
                    return (decimal?)(Convert.ToDecimal(value));
                }
                catch (Exception)
                {
                    throw new FormatException("Cannot parse value (" + value.ToString() + ") to Decimal");
                }
            }
        }
    }
}
