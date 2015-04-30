using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataImport;

namespace Hatfield.EnviroData.DataImport.CSV
{
    public class CSVDataSourceLocation : IDataSourceLocation
    {
        private int _row;
        private int _column;

        public CSVDataSourceLocation(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int Row
        {
            get 
            {
                return _row;
            }
        }

        public int Column
        {
            get
            {
                return _column;
            }
        }
    }
}
