using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class CSVDataToImport : IDataToImport
    {
        private string[][] _rows;
        private string _fileName;

        public CSVDataToImport(string fileName, string[][] rows)
        {
            _fileName = fileName;
            _rows = rows;            
        }

        public object Data
        {
            get { return _rows; }
        }

        public string FileName
        {
            get { return _fileName; }
        }
    }
}
