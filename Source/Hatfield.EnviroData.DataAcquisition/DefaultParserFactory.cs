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
            else if (type == typeof(bool))
            {
                return new BooleanValueParser();
            }
            else if (type == typeof(decimal))
            {
                return new DecimalValueParser();
            }

            else if (type == typeof(int?))
            {
                return new NullableIntValueParser();
            } 
            else if (type == typeof(double?))
            {
                return new NullableDoubleValueParser();
            }          
            else if (type == typeof(DateTime?))
            {
                return new NullableDateTimeValueParser();
            }
            else if (type == typeof(decimal?))
            {
                return new NullableDecimalValueParser();
            }
            else
            {
                throw new NotSupportedException(type.Name + " is not a supported value type");
            }
        }
    }
}
