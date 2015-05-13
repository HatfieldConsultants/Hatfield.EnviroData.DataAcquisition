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
        DataFromFileSystem FetchData();//Get the exact file path to fetch data
        IEnumerable<DataFromFileSystem> FetchData(IEnumerable<IFileSystemFilter> filters);//fetch files by filters
    }
}
