using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.ValueParsers;

namespace Hatfield.EnviroData.DataAcquisition
{
    public class DefaultParserFactory : IParserFactory
    {             

        public virtual IValueParser GetValueParser(Type type)
        {
            if(type == typeof(int))
            {
                return new IntValueParser();
            }
            else if (type == typeof(double))
            {
                return new DoubleValueParser();
            }
            else if (type == typeof(string))
            {
                return new StringValueParser();
            }
            else if (type == typeof(DateTime))
            {
                return new DateTimeValueParser();
            }
            else
            {
                throw new NotSupportedException(type.Name + " is not a supported value type");
            }
        }
    }
}
