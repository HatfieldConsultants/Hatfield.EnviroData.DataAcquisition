using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class CSVDataToImport : IDataToImport
    {
        private string[][] _rows;
        private int _rowToStartExtractData = 0;

        public CSVDataToImport(string[][] rows, int startRow = 0)
        {
            _rows = rows;
            _rowToStartExtractData = startRow;
        }

        public object Data
        {
            get { return _rows; }
        }
    }
}
