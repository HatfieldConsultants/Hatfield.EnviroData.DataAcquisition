using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IExtractConfiguration
    {
        string PropertyPath { get; }
        IParser PropertyParser { get; }
        IValueAssigner PropertyValueAssigner { get; }
        IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport, int currentRow);
    }
}
