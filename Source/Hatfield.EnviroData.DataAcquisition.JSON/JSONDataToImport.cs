using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Hatfield.EnviroData.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.JSON
{
    public class JSONDataToImport : IDataToImport
    {
        JObject _jsonObject = null;

        public JSONDataToImport(string jsonString)
        {
            _jsonObject = JObject.Parse(jsonString);
        }

        public JSONDataToImport(DataFromFileSystem dataFromFileSystem)
        {
            var streamReader = new StreamReader(dataFromFileSystem.InputStream);

            using (streamReader)//make sure the text reader is closed as soon as possible
            {
                _jsonObject = JObject.Parse(streamReader.ReadToEnd());
            }
        }

        public object Data
        {
            get { return _jsonObject; }
        }
    }
}
