using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.Test.FileSystems
{
    [TestFixture]
    public class NetworkFileSystemTest
    {
        [Test]
        [ExpectedException(typeof(IOException))]
        public void InvalidNetworkDownloadTest()
        {
            var filePath = @"\\machine-name\invalid\path\file.txt";
            var networkFileSystem = new NetworkFileSystem(filePath);
            var dataFromFileSystem = networkFileSystem.FetchData();
        }
    }
}
