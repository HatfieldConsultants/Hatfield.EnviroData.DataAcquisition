using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.CSV.Parsers;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class DefaultCSVParserFactory : DefaultParserFactory, ICSVParserFactory
    {
        public IParser GetCellParser(Type type)
        {
            return new CellParser(this);
        }

    }
}
