using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport.CSV
{
    public class CSVDataToImport : IDataToImport
    {
        private string[][] _rows;

        public CSVDataToImport(string[][] rows)
        {
            _rows = rows;
        }

        public object Data
        {
            get { return _rows; }
        }
    }
}
