﻿using System;
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
                var rawValue = castedJObject.SelectTokens(locationPath).Cast<JValue>();
                var valueParser = _parserFactory.GetValueParser(type);

                var parsedValue = from value in rawValue
                                  select valueParser.Parse(value);

                return new ParsingResult(ResultLevel.INFO, "Parse value from " + dataToImport.ToString() + " successfully, the value is " + parsedValue.ToString(), parsedValue);
                
            }
            else
            {
                var rawValue = (castedJObject.SelectToken(locationPath) as JValue).Value;
                var valueParser = _parserFactory.GetValueParser(type);
                var parsedValue = valueParser.Parse(rawValue);

                return new ParsingResult(ResultLevel.INFO, "Parse value from " + dataToImport.ToString() + " successfully " + parsedValue, parsedValue);
            }
                        
        }
    }
}
