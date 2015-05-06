using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Hatfield.EnviroData.DataAcquisition.FileSystems
{
    public class DataFromFileSystem
    {
        private String _fileName;
        private Stream _stream;

        public DataFromFileSystem(string fileName, Stream stream)
        {
            _fileName = fileName;
            _stream = stream;
        }

        public string FileName {
            get {
                return _fileName;
            }
        }
        public Stream InputStream {
            get {
                return _stream;
            }
        }

    }
}
