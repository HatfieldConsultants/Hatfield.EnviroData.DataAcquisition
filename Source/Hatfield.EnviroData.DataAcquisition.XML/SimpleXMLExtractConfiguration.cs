using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML
{
    public class SimpleXMLExtractConfiguration : ISimpleExtractConfiguration
    {
        //private int _elementIndex;
        private string _propertyPath;
        private IParser _parser;
        private IValueAssigner _valueAssigner;
        private Type _propertyType;
        private string _element;
        private string _attribute;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnIndex">The column index to get the data, zero based</param>
        /// <param name="propertyPath"></param>
        /// <param name="parser"></param>
        /// <param name="valueAssigner"></param>
        /// <param name="propertyType"></param>
        /// 
        public SimpleXMLExtractConfiguration(string elementName, string attributeName, IParser parser, IValueAssigner valueAssigner, Type propertyType, string propertyPath)
        {
            _element = elementName;
            _attribute = attributeName;
            _parser = parser;
            _valueAssigner = valueAssigner;
            _propertyType = propertyType;
            _propertyPath = propertyPath;
        }

        public string ElementName
        {
            get
            {
                return _element;
            }
        }

        public string AttributeName
        {
            get
            {
                return _attribute;
            }
        }

        //public int ElementIndex
        //{
        //    get
        //    {
        //        return _elementIndex;
        //    }
        //}

        public string PropertyPath
        {
            get
            {
                return _propertyPath;
            }
        }

        public IParser PropertyParser
        {
            get
            {
                return _parser;
            }
        }

        public IValueAssigner PropertyValueAssigner
        {
            get
            {
                return _valueAssigner;
            }
        }


        public IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport, IDataSourceLocation locationToParse)
        {
            var results = new List<IResult>();
            
            try
            {
                var parsingResult = _parser.Parse(dataToImport, locationToParse, _propertyType) as IParsingResult;

                _valueAssigner.AssignValue(model, _propertyPath, parsingResult.Value, _propertyType);

                results.Add(new BaseResult(ResultLevel.DEBUG, string.Format("Extract data from xml file and assign to model {0}", locationToParse.ToString())));
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new BaseResult(ResultLevel.ERROR, string.Format("Extract data from xml file and assign to model fail. {0}", locationToParse.ToString())));
            }

            return results;
        }
    }
}
