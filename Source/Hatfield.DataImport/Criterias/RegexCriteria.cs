using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Hatfield.EnviroData.DataImport.Criterias
{
    public class RegexCriteria : ICriteria
    {
        private string _matchingRegex;

        public RegexCriteria(string matchingRegex)
        {
            _matchingRegex = matchingRegex;
        }

        public bool Meet(object value)
        {
            return Regex.IsMatch(value.ToString(), _matchingRegex, RegexOptions.IgnoreCase);
        }

        public virtual string Description
        {
            get { return string.Format("Value containing text that matches pattern \"{0}\"", _matchingRegex); }
        }
    }
}
