using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public interface ICSVParserFactory : IParserFactory
    {
        IParser GetCellParser(Type type);
    }
}
