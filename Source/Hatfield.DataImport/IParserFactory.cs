using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IParserFactory
    {
        IParser GetParser(Type type);
        IValueParser GetValueParser(Type type);
    }
}
