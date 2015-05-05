using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules
{
    public class CellValueMatchCriteriaValidationRule : IValidationRule
    {
        private IDataSourceLocation _location;
        private ICSVParserFactory _parserFactory;
        private Type _cellValueType;
        private ICriteria _criteria;

        public CellValueMatchCriteriaValidationRule(IDataSourceLocation location,
                                                    ICSVParserFactory parserFactory, 
                                                    Type cellValueType, 
                                                    ICriteria criteria)
        {
            _location = location;
            _parserFactory = parserFactory;
            _cellValueType = cellValueType;
            _criteria = criteria;
        }

        public IResult Validate(IDataToImport dataToImport)
        {
            try
            {
                var valueParser = _parserFactory.GetCellParser(_cellValueType);
                var parsedValue = valueParser.Parse(dataToImport, _location, _cellValueType) as IParsingResult;

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
            catch(Exception)
            {
                return new BaseResult(ResultLevel.ERROR, "System not able to compare to the criteria since parsing value from data fail.");
            }
            
        }
    }
}
