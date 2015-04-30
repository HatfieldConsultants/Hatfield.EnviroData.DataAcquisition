using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using CsvHelper;

using Hatfield.EnviroData.DataImport;

namespace Hatfield.EnviroData.DataImport.CSV
{
    public class CSVDataSource : IDataSource
    {
        private TextReader _textReader;        

        public CSVDataSource(string filePath)
        {
            _textReader = File.OpenText(filePath);
        }

        public CSVDataSource(TextReader textReader)
        {
            _textReader = textReader;
        }

        public CSVDataSource(Stream stream)
        {
            _textReader = new StreamReader(stream);
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

            return new CSVDataToImport(allRows.ToArray());
        }
    }
}
