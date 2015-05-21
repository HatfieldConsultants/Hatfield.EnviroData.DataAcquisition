using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Importers
{
    public class SimpleCSVDataImporter : IDataImporter
    {
        private IList<IExtractConfiguration> _extractConfigurations;
        private IList<IValidationRule> _validationRules;
        private int _startRow = 0;
        private ResultLevel _thresholdLevel = ResultLevel.ERROR;

        public SimpleCSVDataImporter(ResultLevel thresholdLevel, int startRow = 0)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _startRow = startRow;
            _thresholdLevel = thresholdLevel;
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

            var csvDataSource = dataToImport as CSVDataToImport;
            var rawData = csvDataSource.Data as string[][];

            for (var i = _startRow; i < rawData.Length; i++)
            {
                var extractResultsForRow = ExtractDataForSingleRow<T>(_extractConfigurations, dataToImport, i);
                extractedDataset.AddParsingResults(extractResultsForRow);

            }

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

        protected IEnumerable<IResult> ExtractDataForSingleRow<T>(IList<IExtractConfiguration> extractConfigurations, IDataToImport dataSource, int currentRow) where T : new()
        {
            var resultsForSingleRow = new List<IResult>();
            var model = new T();

            IDataSourceLocation currentLocation = null;

            foreach(var configuration in extractConfigurations.Where(x => x is ISimpleExtractConfiguration).Cast<ISimpleExtractConfiguration>())
            {
                if(configuration is SimpleCSVExtractConfiguration)
                {
                    currentLocation = new CSVDataSourceLocation(currentRow, ((SimpleCSVExtractConfiguration)configuration).ColumnIndex);
                }
                resultsForSingleRow.AddRange(configuration.ExtractData(model, dataSource, currentLocation));
            }

            var parsingResult = new ParsingResult(ResultLevel.DEBUG, "Extract data from single row success", model);

            resultsForSingleRow.Add(parsingResult);

            return resultsForSingleRow;

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
