using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IDataAcquisitioner
    {
        bool IsDataSourceSupported(IDataSource dataSource);
        IExtractedDataset Extract(IDataSource dataSource);
        IEnumerable<ICriteria> AllCriteria { get; }
        IEnumerable<IExtractConfiguration> ExtractConfigurations { get; }
    }
}
