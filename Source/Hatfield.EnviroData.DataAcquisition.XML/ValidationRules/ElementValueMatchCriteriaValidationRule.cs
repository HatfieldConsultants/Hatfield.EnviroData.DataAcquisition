using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.XML.ValidationRules
{
    public class ElementValueMatchCriteriaValidationRule : IValidationRule
    {
        private IDataSourceLocation _location;
        private IXMLParserFactory _parserFactory;
        private Type _elementValueType;
        private ICriteria _criteria;

        public ElementValueMatchCriteriaValidationRule(IDataSourceLocation location,
                                                    IXMLParserFactory parserFactory,
                                                    Type elementValueType,
                                                    ICriteria criteria)
        {
            _location = location;
            _parserFactory = parserFactory;
            _elementValueType = elementValueType;
            _criteria = criteria;
        }

        public IResult Validate(IDataToImport dataToImport)
        {
            try
            {
                var valueParser = _parserFactory.GetElementParser(_elementValueType);
                var parsedValue = valueParser.Parse(dataToImport, _location, _elementValueType) as IParsingResult;

                var isCriteriaMet = _criteria.Meet(parsedValue.Value);

                if (isCriteriaMet)
                {
                    return new BaseResult(ResultLevel.INFO, "Criteria matches");
                }
                else
                {
                    return new BaseResult(ResultLevel.ERROR, "Criteria not matches");
                }
            }
            catch (Exception)
            {
                return new BaseResult(ResultLevel.ERROR, "System not able to compare to the criteria since parsing value from data fail.");
            }

        }
    }
}
