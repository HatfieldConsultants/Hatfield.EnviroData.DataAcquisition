using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.XML
{

    public interface IXMLParserFactory : IParserFactory
    {
        IParser GetElementParser(Type type);
    }
}
