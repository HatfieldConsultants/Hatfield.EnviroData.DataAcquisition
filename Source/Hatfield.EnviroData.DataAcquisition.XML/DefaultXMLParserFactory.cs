using Hatfield.EnviroData.DataAcquisition.XML.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.XML
{
    public class DefaultXMLParserFactory : DefaultParserFactory, IXMLParserFactory
    {
        public IParser GetElementParser(Type type)
        {
            return new ElementParser(this);
        }

    }
}

