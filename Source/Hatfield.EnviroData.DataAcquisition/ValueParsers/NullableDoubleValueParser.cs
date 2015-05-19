using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ValueParsers
{
    public class NullableDoubleValueParser : IValueParser
    {
        public virtual object Parse(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return null;
            }
            else
            {
                try
                {
                    return (double?)(Convert.ToDouble(value));
                }
                catch (Exception)
                {
                    throw new FormatException("Can not parse value (" + value.ToString() + ") to double");
                }
            }

        }
    }
}
