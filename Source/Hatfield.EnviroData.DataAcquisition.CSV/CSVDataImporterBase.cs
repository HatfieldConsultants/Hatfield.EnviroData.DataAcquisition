using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.CSV
{
    public abstract class CSVDataImporterBase : IDataImporter
    {
        public virtual bool IsDataSourceSupported(IDataToImport dataSource)
        {
            if (dataSource.GetType() == typeof(CSVDataSource))
            {
                return ValidateFormat(dataSource);
            }
            else
            {
                return false;
            }
        }

        public IExtractedDataset Extract(IDataToImport dataSource)
        {
            if (IsDataSourceSupported(dataSource))
            {
                return ExtractDataFromValidatedDataSource(dataSource);
            }
            else
            {
                //return data file type or format not support result
                return null;
            }
        }

        protected abstract bool ValidateFormat(IDataToImport dataSource);
        protected abstract IExtractedDataset ExtractDataFromValidatedDataSource(IDataToImport dataSource);


        public IEnumerable<ICriteria> AllCriteria
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IExtractConfiguration> ExtractConfigurations
        {
            get { throw new NotImplementedException(); }
        }
    }
}
