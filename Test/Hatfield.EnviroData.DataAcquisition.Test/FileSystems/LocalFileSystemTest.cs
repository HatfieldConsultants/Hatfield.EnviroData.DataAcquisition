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
    public class LocalFileSystemTest
    {
        [Test]
        public void LocalFileSystemFetchDataTest()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "test.txt");

            var localFileSystem = new LocalFileSystem(filePath);

            var dataFromFileSystem = localFileSystem.FetchData();

            Assert.AreEqual("test.txt", dataFromFileSystem.FileName);

            var streamReader = new StreamReader(dataFromFileSystem.InputStream);
            var dataIntheFile = streamReader.ReadToEnd();

            Assert.AreEqual("123", dataIntheFile);
        }
    }
}
