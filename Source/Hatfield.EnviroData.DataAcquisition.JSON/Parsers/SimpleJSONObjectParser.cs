using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hatfield.EnviroData.DataAcquisition.JSON.Parsers
{
    public class SimpleJSONObjectParser : IParser
    {
        private IParserFactory _parserFactory;

        public SimpleJSONObjectParser(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public IResult Parse(IDataToImport dataToImport, IDataSourceLocation dataSourceLocation, Type type)
        {
            var castedDataToImport = dataToImport as JSONDataToImport;
            var castedJObject = castedDataToImport.Data as JObject;

            var castedDataSourceLocation = dataSourceLocation as JSONDataSourceLocation;
            var locationPath = castedDataSourceLocation.Path;

            if (castedDataSourceLocation.IsArray)
            {
                var rawValues = castedJObject.SelectTokens(locationPath).Values<string>();
                var valueParser = _parserFactory.GetValueParser(type);

                var parsedValue = from value in rawValues
                                  select valueParser.Parse(value);


                return new ParsingResult(ResultLevel.INFO, "Parse value from " + dataToImport.ToString() + " successfully, the value is " + parsedValue.ToString(), parsedValue.ToList(), castedDataSourceLocation);
                
            }
            else
            {
                var rawValue = (castedJObject.SelectTokens(locationPath).ElementAt(castedDataSourceLocation.Index.Value) as JValue).Value;
                var valueParser = _parserFactory.GetValueParser(type);
                var parsedValue = valueParser.Parse(rawValue);

                return new ParsingResult(ResultLevel.INFO, "Parse value from " + dataToImport.ToString() + " successfully " + parsedValue, parsedValue, castedDataSourceLocation);
            }
                        
        }
    }
}
