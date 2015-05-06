using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.FileSystems
{
    public class LocalFileSystem : IFileSystem
    {
        private string _filePath;

        public LocalFileSystem(string filePath)
        {
            _filePath = filePath;
        }

        public DataFromFileSystem FetchData()
        {
            var fileName = Path.GetFileName(_filePath);
            var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);

            return new DataFromFileSystem(fileName, fileStream);
        }
    }
}
