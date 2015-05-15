using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using NUnit.Framework;

using Hatfield.EnviroData.DataAcquisition.FileSystems;
using Hatfield.EnviroData.DataAcquisition.Test.FileSystems.Filters;

namespace Hatfield.EnviroData.DataAcquisition.Test.FileSystems
{
    [TestFixture]
    public class FtpFileSystemTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        [TestCase("http://httpsite.com")]
        [TestCase("https://httpssite.com")]
        public void FtpFileSystemAnonymousNotFtpTest(string uri)
        {
            var ftpFileSystem = new FtpFileSystem(uri);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        [TestCase("http://httpsite.com")]
        [TestCase("https://httpssite.com")]
        public void FtpFileSystemSecureNotFtpTest(string uri)
        {
            var ftpFileSystem = new FtpFileSystem(uri, "username", "password");
        }

        [Test]
        [ExpectedException(typeof(UriFormatException))]
        [TestCase("not a valid uri")]
        [TestCase("www.host.com")]
        [TestCase("host.com")]
        public void AnonymousFetchDataInvalidUriTest(string uri)
        {
            var ftpFileSystem = new FtpFileSystem(uri);
        }

        [Test]
        [ExpectedException(typeof(UriFormatException))]
        [TestCase("not a valid uri")]
        [TestCase("www.host.com")]
        [TestCase("host.com")]
        public void SecureFetchDataInvalidUriTest(string uri)
        {
            var ftpFileSystem = new FtpFileSystem(uri, "username", "password");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AnonymousFetchDataNullUriTest()
        {
            var ftpFileSystem = new FtpFileSystem(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SecureFetchDataNullUriTest()
        {
            var ftpFileSystem = new FtpFileSystem(null, "username", "password");
        }
    }
}
