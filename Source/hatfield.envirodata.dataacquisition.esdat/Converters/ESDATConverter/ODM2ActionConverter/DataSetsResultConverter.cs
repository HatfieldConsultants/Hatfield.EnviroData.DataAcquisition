using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DataSetsResultConverter : ESDATDataConverterBase
    {
        public DataSetsResultConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public DataSetsResult Convert(Result result, ChemistryFileData chemistry, DatasetConverter dataSetConverter)
        {
            DataSetsResult dataSetsResult = new DataSetsResult();

            dataSetsResult.DataSet = dataSetConverter.Convert(dataSetsResult, chemistry);
            dataSetsResult.Result = result;

            return dataSetsResult;
        }
    }
}
