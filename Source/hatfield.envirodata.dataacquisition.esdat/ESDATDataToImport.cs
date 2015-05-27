using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.CSV;
using Hatfield.EnviroData.DataAcquisition.XML;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATDataToImport : IDataToImport
    {
        private XMLDataToImport _headerFileToImport;
        private CSVDataToImport _sampleFileToImport;
        private CSVDataToImport _chemistryFileToImport;

        public ESDATDataToImport(XMLDataToImport headerFileToImport, CSVDataToImport sampleFileToImport, CSVDataToImport chemistryFileToImport)
        {
            _headerFileToImport = headerFileToImport;
            _sampleFileToImport = sampleFileToImport;
            _chemistryFileToImport = chemistryFileToImport;
        }

        public object Data
        {
            get {
                return this;
            }
        }

        public XMLDataToImport HeaderFileToImport
        {
            get
            {
                return _headerFileToImport;
            }
        }

        public CSVDataToImport SampleFileToImport
        {
            get { return _sampleFileToImport; }
        }

        public CSVDataToImport ChemistryFileToImport
        {
            get { return _chemistryFileToImport; }
        }
    }
}
