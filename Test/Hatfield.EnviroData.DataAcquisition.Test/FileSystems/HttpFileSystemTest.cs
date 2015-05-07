using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.Test.FileSystems
{
    [TestFixture]
    public class HttpFileSystemTest
    {
        [Test]
        [ExpectedException(typeof(UriFormatException))]
        public void InvalidUriTest()
        {
            var uri = "invalid uri";
            var httpFileSystem = new HttpFileSystem(uri);
            var dataFromFileSystem = httpFileSystem.FetchData();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUriTest()
        {
            var httpFileSystem = new HttpFileSystem(null);
            httpFileSystem.FetchData();
        }

        [Test]
        [Ignore]
        public void DownloadTest()
        {
            var uri = "http://site.com/file";
            var httpFileSystem = new HttpFileSystem(uri);
            var dataFromFileSystem = httpFileSystem.FetchData();
            var fileStream = dataFromFileSystem.InputStream;
            var fileName = dataFromFileSystem.FileName;
            var output = File.Create("C:\\" + fileName);
            fileStream.CopyTo(output);
            output.Close();
            Assert.IsTrue(true);
        }
    }
}
