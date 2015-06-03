using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.JSON
{
    public class JSONDataSourceLocation : IDataSourceLocation
    {
        private string _path;
        private bool _isArray;

        public JSONDataSourceLocation(string path, bool isArray)
        {
            _path = path;
            _isArray = isArray;
        }

        public string Path
        {
            get {
                return _path;
            }
        }

        public bool IsArray
        {
            get {
                return _isArray;
            }
        }
    }
}
