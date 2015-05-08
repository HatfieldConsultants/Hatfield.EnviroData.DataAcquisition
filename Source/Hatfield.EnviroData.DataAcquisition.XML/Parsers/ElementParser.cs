using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML.Parsers
{
    public class ElementParser : IParser
    {
        private IParserFactory _parserFactory;

        public ElementParser(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public IResult Parse(IDataToImport dataToImport, IDataSourceLocation dataSourceLocation, Type type)
        {
            if (!(dataSourceLocation is XMLDataSourceLocation))
            {
                return new ParsingResult(ResultLevel.FATAL, dataSourceLocation.GetType().ToString() + " is not supported by XML Node Parser", null);
            }

            if (!(dataToImport is XMLDataToImport))
            {
                return new ParsingResult(ResultLevel.FATAL, dataToImport.GetType().ToString() + " is not supported by XML Node Parser", null);
            }


            var castedDataToImport = dataToImport as XMLDataToImport;
            var castedDataSourceLocation = dataSourceLocation as XMLDataSourceLocation;

            try
            {
                var rawData = GetRawDataValue(castedDataSourceLocation, castedDataToImport);
                var parsedValue = ParseRawValue(type, rawData);

                return new ParsingResult(ResultLevel.INFO, "Parsing value successfully", parsedValue);
            }
            catch (IndexOutOfRangeException)
            {
                return new ParsingResult(ResultLevel.FATAL, "Index is out of range", null);
            }
        }

        private string GetRawDataValue(XMLDataSourceLocation location, XMLDataToImport xmlDataToImport)
        {
            var data = xmlDataToImport.Data as XDocument;
            return data.Root.Element(location.ElementName).ToString();
        }

        private object ParseRawValue(Type type, string elementValue)
        {
            var valueParser = _parserFactory.GetValueParser(type);

            var parsedValue = valueParser.Parse(elementValue);

            return parsedValue;
        }
    }
}
