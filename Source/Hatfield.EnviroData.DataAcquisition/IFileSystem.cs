using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IFileSystem
    {
        DataFromFileSystem FetchData();
    }
}
