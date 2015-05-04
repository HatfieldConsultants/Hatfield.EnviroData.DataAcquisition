using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IDataImporter
    {
        bool IsDataSourceSupported(IDataToImport dataSource);
        IExtractedDataset Extract<T>(IDataToImport dataSource);
        IEnumerable<IValidationRule> AllValidationRules { get; }
        IEnumerable<IExtractConfiguration> ExtractConfigurations { get; }
    }
}
