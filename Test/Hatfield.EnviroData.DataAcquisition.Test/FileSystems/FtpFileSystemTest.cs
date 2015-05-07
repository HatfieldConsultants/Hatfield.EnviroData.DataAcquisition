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
    public class FtpFileSystemTest
    {
        [Test]
        [ExpectedException(typeof(UriFormatException))]
        public void InvalidUriTest()
        {
            var uri = "invalid uri";
            var httpFileSystem = new FtpFileSystem(uri);
            var dataFromFileSystem = httpFileSystem.FetchData();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullUriTest()
        {
            var httpFileSystem = new FtpFileSystem(null);
            httpFileSystem.FetchData();
        }

        [Test]
        [Ignore]
        public void AnonymousDownloadTest()
        {
            var uri = "ftp://site.com/file";
            var ftpFileSystem = new FtpFileSystem(uri);
            var dataFromFileSystem = ftpFileSystem.FetchData();
            var fileStream = dataFromFileSystem.InputStream;
            var fileName = dataFromFileSystem.FileName;
            var output = File.Create("C:\\" + fileName);
            fileStream.CopyTo(output);
            output.Close();
            Assert.IsTrue(true);
        }
    }
}
