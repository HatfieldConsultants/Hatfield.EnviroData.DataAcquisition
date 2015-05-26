namespace Hatfield.EnviroData.DataAcquisition.XML.ValidationRules
{
    using System;

    public class XMLFileNameExtensionMatchValidationRule : IValidationRule
    {
        private string _acceptedFileExtension;
        private bool _caseSensitive;

        public XMLFileNameExtensionMatchValidationRule(string acceptedFileExtension, bool caseSensitive)
        {
            _acceptedFileExtension = acceptedFileExtension;
            _caseSensitive = caseSensitive;
        }

        public IResult Validate(IDataToImport dataToImport)
        {
            var xmlDataToImport = (XMLDataToImport)dataToImport;

            if (xmlDataToImport != null)
            {
                if (string.IsNullOrEmpty(xmlDataToImport.FileName))
                {
                    return new BaseResult(ResultLevel.ERROR, "System fail to compare file extension because data file name is empty/null");
                }
                else
                {
                    var isValid = _caseSensitive ?
                                    xmlDataToImport.FileName.EndsWith(_acceptedFileExtension, StringComparison.Ordinal) :
                                    xmlDataToImport.FileName.EndsWith(_acceptedFileExtension, StringComparison.OrdinalIgnoreCase);

                    if (isValid)
                    {
                        return new BaseResult(ResultLevel.INFO,
                                              string.Format("File name {0} matches the extension {1}",
                                                            xmlDataToImport.FileName,
                                                            _acceptedFileExtension));
                    }
                    else
                    {
                        return new BaseResult(ResultLevel.ERROR,
                                              string.Format("File name {0} does not match the extension {1}",
                                                            xmlDataToImport.FileName,
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