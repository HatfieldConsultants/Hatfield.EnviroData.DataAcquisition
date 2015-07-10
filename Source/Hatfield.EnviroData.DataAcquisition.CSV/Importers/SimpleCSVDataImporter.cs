using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV.Importers
{
    public class SimpleCSVDataImporter : DataImporterBase
    {
        private int _startRow = 0;


        public SimpleCSVDataImporter(ResultLevel thresholdLevel, int startRow = 0)
            : base(thresholdLevel)
        {
            _startRow = startRow;
        }

        public override bool IsDataSupported(IDataToImport dataToImport)
        {
            return ValidateDataToImport(dataToImport).Item1;
        }

        public override IExtractedDataset<T> Extract<T>(IDataToImport dataToImport)
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


        protected IEnumerable<IResult> ExtractDataForSingleRow<T>(IList<IExtractConfiguration> extractConfigurations, IDataToImport dataSource, int currentRow) where T : new()
        {
            var resultsForSingleRow = new List<IResult>();
            var model = new T();

            IDataSourceLocation currentLocation = null;

            foreach (var configuration in extractConfigurations.Where(x => x is ISimpleExtractConfiguration).Cast<ISimpleExtractConfiguration>())
            {
                if (configuration is SimpleCSVExtractConfiguration)
                {
                    currentLocation = new CSVDataSourceLocation(currentRow, ((SimpleCSVExtractConfiguration)configuration).ColumnIndex);
                }
                resultsForSingleRow.AddRange(configuration.ExtractData(model, dataSource, currentLocation));
            }

            var parsingResult = new ParsingResult(ResultLevel.DEBUG, "Extract data from single row success", model, new CSVDataSourceLocation(currentRow, 1));

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