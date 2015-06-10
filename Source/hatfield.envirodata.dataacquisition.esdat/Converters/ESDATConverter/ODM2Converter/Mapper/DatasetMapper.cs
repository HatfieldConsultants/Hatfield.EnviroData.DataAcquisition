using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetMapper : ODM2MapperBase
    {
        // Constants
        private const string DataSetTypeCV = "other";

        public DatasetMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public DataSet Map(DataSetsResult datasetsResult, ESDATModel esdatModel)
        {
            return this.Scaffold(datasetsResult, esdatModel);
        }

        public DataSet Map(DataSetsResult datasetsResult, ChemistryFileData chemistry)
        {
            return this.Scaffold(datasetsResult, chemistry);
        }

        public DataSet Scaffold(DataSetsResult datasetsResult, ESDATModel esdatModel)
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

        public DataSet Scaffold(DataSetsResult datasetsResult, ChemistryFileData chemistry)
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
