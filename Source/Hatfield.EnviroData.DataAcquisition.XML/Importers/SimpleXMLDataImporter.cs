using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML.Importers
{
    public class SimpleXMLDataImporter: IDataImporter
    {        
        private IList<IExtractConfiguration> _extractConfigurations;
        private IList<IValidationRule> _validationRules;
        private ResultLevel _thresholdLevel = ResultLevel.ERROR;
        private XMLDataSourceLocation _location;

        public SimpleXMLDataImporter(ResultLevel thresholdLevel)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _thresholdLevel = thresholdLevel;
            //_location = location;
        }
      
        public bool IsDataSupported(IDataToImport dataToImport)
        {
            return ValidateDataToImport(dataToImport).Item1;
        }

        public IExtractedDataset<T> Extract<T>(IDataToImport dataToImport) where T : new()
        {            
            var extractedDataset = new ExtractedDataset<T>(_thresholdLevel);
            var validatedDataToImportResult = ValidateDataToImport(dataToImport);
            extractedDataset.AddParsingResults(validatedDataToImportResult.Item2);

            if (!validatedDataToImportResult.Item1)
            {
                //format not valid, return
                return extractedDataset;
            }
            var results = new List<IResult>();
            var model = new T();
            IDataSourceLocation currentLocation = null;

            foreach (var configuration in _extractConfigurations)
            {               
                if (configuration is SimpleXMLExtractConfiguration)
                {
                    currentLocation = new XMLDataSourceLocation(((SimpleXMLExtractConfiguration)configuration).ElementName, ((SimpleXMLExtractConfiguration)configuration).AttributeName);
                }

                results.AddRange(((SimpleXMLExtractConfiguration)configuration).ExtractData(model, dataToImport, currentLocation));
                              
            }
            var parsingResult = new ParsingResult(ResultLevel.DEBUG, "Extract data from single row success", model);
            
            results.Add(parsingResult);

            extractedDataset.AddParsingResults(results);

            return extractedDataset;
        }

        public IEnumerable<IValidationRule> AllValidationRules
        {
            get {
                return _validationRules;
            }
        }

        public IEnumerable<IExtractConfiguration> ExtractConfigurations
        {
            get {
                return _extractConfigurations;
            }
        }

        public void AddExtractConfiguration(IExtractConfiguration extractConfigurationToAdd)
        {
            _extractConfigurations.Add(extractConfigurationToAdd);
        }

        public void AddValidationRule(IValidationRule validationRuleToAdd)
        {
            _validationRules.Add(validationRuleToAdd);
        }

        public ResultLevel ThresholdLevel
        {
            get { return _thresholdLevel; }
        }

        private Tuple<bool, IEnumerable<IResult>> ValidateDataToImport(IDataToImport dataToImport)
        {
            var allValidationResults = from rule in _validationRules
                                       select rule.Validate(dataToImport);

            var isValid = !allValidationResults.Any(x => ResultLevelHelper.LevelIsHigherThanOrEqualToThreshold(_thresholdLevel, x.Level));

            return new Tuple<bool, IEnumerable<IResult>>(isValid, allValidationResults);
        }
    }
}
