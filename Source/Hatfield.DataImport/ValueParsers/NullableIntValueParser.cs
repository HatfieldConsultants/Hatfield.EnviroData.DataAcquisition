using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.ValueParsers
{
    public class NullableIntValueParser : IValueParser
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
                    return (int?)(Convert.ToInt32(value));
                }
                catch (Exception)
                {
                    throw new FormatException("Can not parse value (" + value.ToString() + ") to integer");
                }
            }

        }
    }
}
