using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML
{
    public class XMLDataSourceLocation
    {
        public string _elementName;
        public XElement _element;

        public XMLDataSourceLocation(string elementName, XElement element)
        {
            _elementName = elementName;
            _element = element;
        }

        public XElement Element
        {
            get
            {
                return _element;
            }
        }

        public string ElementName
        {
            get
            {
                return _elementName;
            }
        }

        public override string ToString()
        {
            return string.Format("Row: {0}, Column: {1}", _element, _elementName);
        }

    }
}
