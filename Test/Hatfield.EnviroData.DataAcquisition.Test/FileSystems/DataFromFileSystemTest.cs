using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;
using Moq;

using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.Test.FileSystems
{
    [TestFixture]
    public class DataFromFileSystemTest
    {
        [Test]
        public void CreateDataFromFileSystemTest()
        {
            var testFileName = "test.csv";
            var mockStream = new Mock<Stream>();

            var testDataFromFileSystem = new DataFromFileSystem(testFileName, mockStream.Object);

            Assert.AreEqual("test.csv", testDataFromFileSystem.FileName);
            Assert.NotNull(testDataFromFileSystem.InputStream);
        }
    }
}
