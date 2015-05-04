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

        public bool IsDataSourceSupported(IDataToImport dataSource)
        {
            throw new NotImplementedException();
        }

        public IExtractedDataset Extract<T>(IDataToImport dataSource)
        {
            throw new NotImplementedException();
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
    }
}
