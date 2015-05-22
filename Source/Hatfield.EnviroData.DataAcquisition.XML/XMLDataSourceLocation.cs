using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML
{
    public class XMLDataSourceLocation: IDataSourceLocation
    {
        public string _elementName;
        public string _attributeName;
        public int _index = 0;

        public XMLDataSourceLocation(string elementName, string attributeName)
        {
            _elementName = elementName;
            _attributeName = attributeName;
        }

        public XMLDataSourceLocation(string elementName, string attributeName, int index)
        {
            _elementName = elementName;
            _attributeName = attributeName;
            _index = index;
        }

        public string AttributeName
        {
            get
            {
                return _attributeName;
            }
        }

        public string ElementName
        {
            get
            {
                return _elementName;
            }
        }

        public int Index
        {
            get
            {
                return _index;
            }
        }

        public override string ToString()
        {
            return string.Format("Node: {0}, {1}",  _elementName, _attributeName);
        }

    }
}
