using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class MapperSourceLocation : IDataSourceLocation
    {
        public string Mapper { get; private set; }
        public string Field { get; private set; }

        public MapperSourceLocation(string converter, string field)
        {
            Mapper = converter;
            Field = field;
        }

        public override string ToString()
        {
            return string.Format("Mapper: {0}, Field: {1}", Mapper, Field);
        }
    }
}
