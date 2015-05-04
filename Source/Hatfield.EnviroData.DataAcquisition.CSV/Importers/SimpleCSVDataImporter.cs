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

        public SimpleCSVDataImporter(int startRow = 0)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _startRow = startRow;
        }

        /// <summary>
        /// Always mark as support now
        /// Need to improve in the future
        /// </summary>
        /// <param name="dataSource"></param>
        /// <returns></returns>
        public bool IsDataSupported(IDataToImport dataSource)
        {
            return true;
        }

        public IExtractedDataset<T> Extract<T>(IDataToImport dataSource) where T : new()
        {
            var extractedDataset = new ExtractedDataset<T>();
            var csvDataSource = dataSource as CSVDataToImport;
            var rawData = csvDataSource.Data as string[][];

            for (var i = _startRow; i < rawData.Length; i++)
            {
                var extractResultsForRow = ExtractDataForSingleRow<T>(_extractConfigurations, dataSource, i);
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

        private IEnumerable<IResult> ExtractDataForSingleRow<T>(IList<IExtractConfiguration> extractConfigurations, IDataToImport dataSource, int currentRow) where T : new()
        {
            var resultsForSingleRow = new List<IResult>();
            var model = new T();

            foreach(var configuration in extractConfigurations)
            {
                resultsForSingleRow.AddRange(configuration.ExtractData(model, dataSource, currentRow));
            }

            var parsingResult = new ParsingResult(ResultLevel.DEBUG, "Extract data from single row success", model);

            resultsForSingleRow.Add(parsingResult);

            return resultsForSingleRow;

        }
    }
}
