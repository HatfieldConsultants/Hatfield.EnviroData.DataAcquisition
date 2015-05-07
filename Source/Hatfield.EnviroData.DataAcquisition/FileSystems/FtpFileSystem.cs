using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.FileSystems
{
    public class FtpFileSystem : IFileSystem
    {
        private Uri _uri;
        private NetworkCredential _credentials;

        public FtpFileSystem(string url)
        {
            _uri = new Uri(url);
            _credentials = new NetworkCredential();
        }

        public FtpFileSystem(string url, string username, string password)
        {
            _uri = new Uri(url);
            _credentials = new NetworkCredential(username, password);
        }

        public DataFromFileSystem FetchData()
        {
            WebClient request = new WebClient();
            request.Credentials = _credentials;
            var fileStream = request.OpenRead(_uri);
            var fileName = System.IO.Path.GetFileName(_uri.LocalPath);

            return new DataFromFileSystem(fileName, fileStream);
        }
    }
}
