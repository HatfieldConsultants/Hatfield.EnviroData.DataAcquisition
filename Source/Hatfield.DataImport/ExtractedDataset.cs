using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public class ExtractedDataset : IExtractedDataset
    {
        private IEnumerable<IResult> _results;
        private ResultLevel _thresholdLevel = ResultLevel.ERROR;

        public ExtractedDataset()
        {
            _results = new List<IResult>();
        }

        public ExtractedDataset(ResultLevel thresholdLevel)
        {
            _results = new List<IResult>();
            _thresholdLevel = thresholdLevel;
        }

        public IEnumerable<object> ExtractedEntities
        {
            get {
                if (IsExtractedSuccess)
                {
                    var entities = from parsingResult in _results
                                   where parsingResult is IParsingResult
                                   select ((IParsingResult)parsingResult).Value;

                    return entities;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsExtractedSuccess
        {
            get {
                var isAllResultUnderThreshold = _results.Where(
                                                                x => ResultLevelHelper.LevelIsHigherThanOrEqualToThreshold(_thresholdLevel, x.Level))
                                                        .Any();

                return !isAllResultUnderThreshold;
            }
        }

        public IEnumerable<IResult> AllParsingResults
        {
            get { return _results; }
        }

        public void AddParsingResult(IResult parsingResult)
        {
            ((IList<IResult>)_results).Add(parsingResult);
        }

        public void AddParsingResults(IEnumerable<IResult> parsingResults)
        {
            _results = _results.Concat(parsingResults);
        }


        public ResultLevel ThresholdLevel
        {
            get { return _thresholdLevel; }
        }
    }
}
