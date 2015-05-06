using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using CsvHelper;

using Hatfield.EnviroData.DataAcquisition.FileSystems;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class CSVDataToImport : IDataToImport
    {
        private string[][] _rows;
        private string _fileName;

        public CSVDataToImport(string fileName, string[][] rows)
        {
            _fileName = fileName;
            _rows = rows;            
        }

        public CSVDataToImport(DataFromFileSystem dataFromFileSystem)
        {
            var streamReader = new StreamReader(dataFromFileSystem.InputStream);
            var csvData = FetchCSVData(streamReader);

            _fileName = dataFromFileSystem.FileName;
            _rows = csvData;
        }

        public object Data
        {
            get { return _rows; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        private string[][] FetchCSVData(StreamReader streamReader)
        {
            var allRows = new List<string[]>();

            using (streamReader)//make sure the text reader is closed as soon as possible
            {
                var csv = new CsvReader(streamReader);
                int numberOfRead = 0;
                while (csv.Read())
                {
                    if (numberOfRead == 0)
                    {
                        //if read for the first time, include the header
                        allRows.Add(csv.FieldHeaders);
                        numberOfRead++;
                    }

                    var row = csv.CurrentRecord;
                    allRows.Add(row);
                }
            }

            return allRows.ToArray();
        }
    }
}
