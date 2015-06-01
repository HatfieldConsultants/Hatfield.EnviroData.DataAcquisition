using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToDataset : ESDATConverterToODMAction
    {
        // Constants
        private const string DataSetTypeCV = "other";

        public ESDATConverterToDataset(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public DataSet Convert(DataSetsResult datasetsResult, ESDATModel esdatModel)
        {
            DataSet dataSet = new DataSet();

            dataSet.DataSetUUID = ToGuid(esdatModel.SDGID);
            dataSet.DataSetTypeCV = DataSetTypeCV;
            dataSet.DataSetCode = string.Empty;
            dataSet.DataSetTitle = string.Empty;
            dataSet.DataSetAbstract = string.Empty;
            dataSet.DataSetsResults.Add(datasetsResult);

            return dataSet;
        }

        public DataSet Convert(DataSetsResult datasetsResult, ChemistryFileData chemistry)
        {
            DataSet dataSet = new DataSet();

            dataSet.DataSetTypeCV = DataSetTypeCV;
            dataSet.DataSetCode = string.Empty;
            dataSet.DataSetTitle = string.Empty;
            dataSet.DataSetAbstract = string.Empty;
            dataSet.DataSetsResults.Add(datasetsResult);

            return dataSet;
        }

        public Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
