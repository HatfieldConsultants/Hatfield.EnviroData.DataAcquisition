using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition.CSV;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATDataToImport : IDataToImport
    {
        private IDataToImport _headerFileToImport;
        private CSVDataToImport _sampleFileToImport;
        private CSVDataToImport _chemistryFileToImport;

        public ESDATDataToImport(IDataToImport headerFileToImport, CSVDataToImport sampleFileToImport, CSVDataToImport chemistryFileToImport)
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

        public IDataToImport HeaderFileToImport
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
