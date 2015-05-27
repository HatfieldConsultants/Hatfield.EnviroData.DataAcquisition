using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public abstract class DataImporterBase : IDataImporter
    {
        protected IList<IExtractConfiguration> _extractConfigurations;
        protected IList<IValidationRule> _validationRules;
        protected ResultLevel _thresholdLevel = ResultLevel.ERROR;

        public DataImporterBase(ResultLevel thresholdLevel)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _thresholdLevel = thresholdLevel;
        }

        public abstract bool IsDataSupported(IDataToImport dataToImport);
        
        public abstract IExtractedDataset<T> Extract<T>(IDataToImport dataToImport) where T : new();


        public IEnumerable<IValidationRule> AllValidationRules
        {
            get { return _validationRules; }
        }

        public IEnumerable<IExtractConfiguration> ExtractConfigurations
        {
            get { return _extractConfigurations; }
        }

        public ResultLevel ThresholdLevel
        {
            get { return _thresholdLevel; }
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
