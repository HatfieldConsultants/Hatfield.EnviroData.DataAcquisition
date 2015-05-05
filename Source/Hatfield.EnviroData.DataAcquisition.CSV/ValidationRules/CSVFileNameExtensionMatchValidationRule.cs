using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV.ValidationRules
{
    public class CSVFileNameExtensionMatchValidationRule : IValidationRule
    {
        private string _acceptedFileExtension;
        private bool _caseSensitive;

        public CSVFileNameExtensionMatchValidationRule(string acceptedFileExtension, bool caseSensitive)
        {
            _acceptedFileExtension = acceptedFileExtension;
            _caseSensitive = caseSensitive;
        }

        public IResult Validate(IDataToImport dataToImport)
        {
            var csvDataToImport = (CSVDataToImport)dataToImport;

            if (csvDataToImport != null)
            {
                if(string.IsNullOrEmpty(csvDataToImport.FileName))
                {
                    return new BaseResult(ResultLevel.ERROR, "System fail to compare file extension because data file name is empty/null");
                }
                else
                {
                    var isValid = _caseSensitive ? 
                                    csvDataToImport.FileName.EndsWith(_acceptedFileExtension, StringComparison.Ordinal) : 
                                    csvDataToImport.FileName.EndsWith(_acceptedFileExtension, StringComparison.OrdinalIgnoreCase);

                    if (isValid)
                    {
                        return new BaseResult(ResultLevel.INFO, 
                                              string.Format("File name {0} matches the extension {1}", 
                                                            csvDataToImport.FileName, 
                                                            _acceptedFileExtension));
                    }
                    else
                    {
                        return new BaseResult(ResultLevel.ERROR, 
                                              string.Format("File name {0} does not match the extension {1}", 
                                                            csvDataToImport.FileName, 
                                                            _acceptedFileExtension));
                    }
                }
                

            }
            else
            {
                return new BaseResult(ResultLevel.ERROR, "Data to import is not in CSV format");
            }
        }
    }
}
