using System.Collections.Generic;
using System.Linq;

namespace Hatfield.EnviroData.DataImport
{
    public class ResultLevelHelper
    {
        private static Dictionary<ResultLevel, ResultLevel[]> levelDictionary = new Dictionary<ResultLevel, ResultLevel[]>{
            {
                ResultLevel.DEBUG, new ResultLevel[] {
                                                        ResultLevel.INFO,
                                                        ResultLevel.WARN,
                                                        ResultLevel.ERROR,
                                                        ResultLevel.FATAL
                                                     }
            },
            {
                ResultLevel.INFO, new ResultLevel[] {
                                                        ResultLevel.WARN,
                                                        ResultLevel.ERROR,
                                                        ResultLevel.FATAL
                                                    }
            },
            {
                ResultLevel.WARN, new ResultLevel[] {
                                                        ResultLevel.ERROR,
                                                        ResultLevel.FATAL
                                                    }
            },
            {
                ResultLevel.ERROR, new ResultLevel[] {
                                                        ResultLevel.FATAL
                                                     }
            },
            {
                ResultLevel.FATAL, new ResultLevel[] {}
            },
        };

        public static bool LevelIsHigherThanOrEqualToThreshold(ResultLevel threshold, ResultLevel actualLevel)
        {
            if (levelDictionary.ContainsKey(threshold))
            {
                return levelDictionary[threshold].Contains(actualLevel) || (threshold == actualLevel);
            }
            else
            {
                throw new KeyNotFoundException(threshold.ToString() + " is not a supported Analysis result level");
            }
        }
    }
}