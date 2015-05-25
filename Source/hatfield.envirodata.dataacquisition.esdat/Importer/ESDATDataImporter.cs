using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Importer
{
    public class ESDATDataImporter : IDataImporter
    {
        private IList<IExtractConfiguration> _extractConfigurations;
        private IList<IValidationRule> _validationRules;
        private ResultLevel _thresholdLevel = ResultLevel.ERROR;

        public ESDATDataImporter(ResultLevel thresholdLevel, int startRow = 0)
        {
            _extractConfigurations = new List<IExtractConfiguration>();
            _validationRules = new List<IValidationRule>();
            _thresholdLevel = thresholdLevel;
        }

        public bool IsDataSupported(IDataToImport dataToImport)
        {
            return dataToImport is ESDATDataToImport;
        }

        public IExtractedDataset<T> Extract<T>(IDataToImport dataToImport) where T : new()
        {
            var extractedDataset = new ExtractedDataset<T>(_thresholdLevel);

            return extractedDataset;
        }

        public IEnumerable<IValidationRule> AllValidationRules
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IExtractConfiguration> ExtractConfigurations
        {
            get { throw new NotImplementedException(); }
        }

        public ResultLevel ThresholdLevel
        {
            get { throw new NotImplementedException(); }
        }
    }
}
