using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface ISimpleExtractConfiguration : IExtractConfiguration
    {
        IParser PropertyParser { get; }
        IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport, IDataSourceLocation currentLocation);
    }
}
