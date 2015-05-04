using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IExtractedDataset<T>
    {
        IEnumerable<T> ExtractedEntities { get; }
        bool IsExtractedSuccess { get; }
        IEnumerable<IResult> AllParsingResults { get; }
        void AddParsingResult(IResult parsingResult);
        void AddParsingResults(IEnumerable<IResult> parsingResults);
        ResultLevel ThresholdLevel { get; }
    }
}
