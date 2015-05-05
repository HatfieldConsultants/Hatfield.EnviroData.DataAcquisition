using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using CsvHelper;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public class CSVDataSource : IDataSource
    {
        private TextReader _textReader;
        private string _fileName;

        public CSVDataSource(string filePath)
        {
            _textReader = File.OpenText(filePath);
            _fileName = Path.GetFileName(filePath);
        }

        public CSVDataSource(string fileName, TextReader textReader)
        {
            _textReader = textReader;
            _fileName = fileName;
        }

        public CSVDataSource(string fileName, Stream stream)
        {
            _textReader = new StreamReader(stream);
            _fileName = fileName;
        }

        public IDataToImport FetchData()
        {            
            var allRows = new List<string[]>();

            using (_textReader)//make sure the text reader is closed as soon as possible
            {
                var csv = new CsvReader(_textReader);
                int numberOfRead = 0;
                while(csv.Read())
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

            return new CSVDataToImport(_fileName, allRows.ToArray());
        }
    }
}
