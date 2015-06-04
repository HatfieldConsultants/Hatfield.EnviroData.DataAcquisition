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
        private int? _index;

        public JSONDataSourceLocation(string path, bool isArray, int? index = null)
        {
            _path = path;
            _isArray = isArray;
            _index = index;

            if (isArray && index.HasValue)
            {
                throw new ArgumentException("JSON location index could not have value if the expected result is an array");
            }
            if (!isArray && !index.HasValue)
            {
                index = 0;
            }
            
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

        public int? Index
        {
            get {
                return _index;
            }
        }
    }
}
