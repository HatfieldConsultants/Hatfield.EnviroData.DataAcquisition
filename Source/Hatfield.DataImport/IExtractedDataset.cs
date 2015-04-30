using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public interface IExtractedDataset
    {
        IEnumerable<object> ExtractedEntities { get; }
        bool IsExtractedSuccess { get; }
        IEnumerable<IResult> AllParsingResults { get; }
        void AddParsingResult(IResult parsingResult);
        void AddParsingResults(IEnumerable<IResult> parsingResults);
        ResultLevel ThresholdLevel { get; }
    }
}
