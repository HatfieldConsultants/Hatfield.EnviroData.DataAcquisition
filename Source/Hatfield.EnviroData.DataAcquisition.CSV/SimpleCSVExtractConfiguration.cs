using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class SimpleCSVExtractConfiguration : IExtractConfiguration
    {
        private int _columnIndex;
        private string _propertyPath;
        private IParser _parser;
        private IValueAssigner _valueAssigner;
        private Type _propertyType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex">The column index to get the data, zero based</param>
        /// <param name="propertyPath"></param>
        /// <param name="parser"></param>
        /// <param name="valueAssigner"></param>
        /// <param name="propertyType"></param>
        public SimpleCSVExtractConfiguration(int columnIndex, string propertyPath, IParser parser, IValueAssigner valueAssigner, Type propertyType)
        {
            _columnIndex = columnIndex;
            _propertyPath = propertyPath;
            _parser = parser;
            _valueAssigner = valueAssigner;
            _propertyType = propertyType;
        }

        public string PropertyPath
        {
            get {
                return _propertyPath;
            }
        }

        public IParser PropertyParser
        {
            get {
                return _parser;
            }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get {
                return _valueAssigner;
            }
        }


        public IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport, int currentRow)
        {
            var results = new List<IResult>();
            var locationToParse = new CSVDataSourceLocation(currentRow, _columnIndex);

            try
            {
                var parsingResult = _parser.Parse(dataToImport, locationToParse, _propertyType) as IParsingResult;

                _valueAssigner.AssignValue(model, _propertyPath, parsingResult.Value, _propertyType);

                results.Add(new BaseResult(ResultLevel.DEBUG, string.Format("Extract data from csv file and assign to model {0}", locationToParse.ToString())));
                return results;
            }
            catch(Exception ex)
            {
                results.Add(new BaseResult(ResultLevel.ERROR, string.Format("Extract data from csv file and assign to model fail. {0}", locationToParse.ToString())));
                
            }
            
            return results;
            
            
        }
    }
}
