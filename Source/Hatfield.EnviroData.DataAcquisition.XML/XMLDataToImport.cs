#region Assembly Hatfield.EnviroData.FileSystems.dll, v1.0.0.0
// C:\Users\gvassas\Desktop\Hatfield.EnviroData.DataAcquisition\\packages\Hatfield.EnviroData.FileSystems.WindowsFileSystem.1.0.0\lib\net40\Hatfield.EnviroData.FileSystems.dll
#endregion
using Hatfield.EnviroData.FileSystems;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Hatfield.EnviroData.DataAcquisition.XML
{
    public class XMLDataToImport:IDataToImport
    {
        public XDocument _document;
        private string _fileName;

        public XMLDataToImport(string fileName, XDocument doc)
        {
            _fileName = fileName;
            _document = doc;
        }

        public XMLDataToImport(DataFromFileSystem dataFromFileSystem)
        {
            var streamReader = new StreamReader(dataFromFileSystem.InputStream);
            var xmlData = FetchXMLData(streamReader);

            _fileName = dataFromFileSystem.FileName;
            _document = xmlData;
        }

        public object Data
        {
            get { return _document; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        private XDocument FetchXMLData(StreamReader streamReader)
        {
            using (streamReader)//make sure the text reader is closed as soon as possible
            {
                var xml = new XmlTextReader(streamReader);
                //var writer = new                 

                return XDocument.Load(xml);
            }
        }
    }
}
