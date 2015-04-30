using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CsvHelper;

using Hatfield.EnviroData.DataImport;

namespace Hatfield.EnviroData.DataImport.CSV.Parsers
{
    public class CellParser : IParser
    {
        private IParserFactory _parserFactory;

        public CellParser(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public IResult Parse<T>(IDataToImport dataToImport, IDataSourceLocation dataSourceLocation)
        {
            if (!(dataSourceLocation is CSVDataSourceLocation))
            {
                return new ParsingResult(ResultLevel.FATAL, dataSourceLocation.GetType().ToString() + " is not supported by CSV Cell Parser", null);                
            }

            if (!(dataToImport is CSVDataToImport))
            {
                return new ParsingResult(ResultLevel.FATAL, dataToImport.GetType().ToString() + " is not supported by CSV Cell Parser", null);                
            }


            var castedDataToImport = dataToImport as CSVDataToImport;
            var castedDataSourceLocation = dataSourceLocation as CSVDataSourceLocation;

            try
            {
                var rawData = GetRawDataValue(castedDataSourceLocation, castedDataToImport);
                var parsedValue = ParseRawValue(typeof(T), rawData);

                return new ParsingResult(ResultLevel.INFO, "Parsing value successfully", parsedValue);
            }
            catch(IndexOutOfRangeException)
            {
                return new ParsingResult(ResultLevel.FATAL, "Index is out of range", null);                
            }
        }

        private string GetRawDataValue(CSVDataSourceLocation location, CSVDataToImport csvDataToImport)
        {
            var data = csvDataToImport.Data as string[][];
            return data[location.Row][location.Column];
        }

        private object ParseRawValue(Type type, string rawValue)
        {
            var valueParser = _parserFactory.GetValueParser(type);

            var parsedValue = valueParser.Parse(rawValue);

            return parsedValue;
        }
    }
}
