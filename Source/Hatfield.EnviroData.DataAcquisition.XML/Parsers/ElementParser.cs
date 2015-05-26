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
            catch (Exception e)
            {
                return new ParsingResult(ResultLevel.FATAL, "Exception caught: " + e, null);
            }
        }

        private string GetRawDataValue(XMLDataSourceLocation location, XMLDataToImport xmlDataToImport)
        {
            var data = xmlDataToImport.Data as XDocument;
            var value = "";

            foreach (XElement element in data.Descendants())
            {
                if (String.IsNullOrEmpty(location.ElementName))
                {
                    return element.Descendants().Attributes().Where(x => x.Name.LocalName == location.AttributeName).FirstOrDefault().Value;
                }
                else
                {
                    var theElement = element.Descendants().Where(x => x.Name.LocalName == location.ElementName).First();
                    return theElement.Attributes().Where(x => x.Name.LocalName == location.AttributeName).First().Value;
                }
            }

            return value;
        }

        private object ParseRawValue(Type type, string elementValue)
        {
            var valueParser = _parserFactory.GetValueParser(type);
            
            return valueParser.Parse(elementValue);
            }
        }
    }

