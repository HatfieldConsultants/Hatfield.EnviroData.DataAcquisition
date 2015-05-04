using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IDataImporter
    {
        bool IsDataSupported(IDataToImport dataToImport);
        IExtractedDataset<T> Extract<T>(IDataToImport dataToImport) where T : new();
        IEnumerable<IValidationRule> AllValidationRules { get; }
        IEnumerable<IExtractConfiguration> ExtractConfigurations { get; }
    }
}
