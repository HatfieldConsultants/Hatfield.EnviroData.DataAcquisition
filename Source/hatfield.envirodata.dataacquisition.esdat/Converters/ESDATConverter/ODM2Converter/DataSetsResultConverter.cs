using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DataSetsResultConverter : ODM2ConverterBase
    {
        public DataSetsResultConverter(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public DataSetsResult Convert(ChemistryFileData chemistry, Result result, IESDATDataConverterFactory converterFactory)
        {
            DataSetsResult dataSetsResult = new DataSetsResult();
            var dataSetConverter = converterFactory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DataSetConverter;

            dataSetsResult.DataSet = dataSetConverter.Convert(dataSetsResult, chemistry);
            dataSetsResult.Result = result;

            return dataSetsResult;
        }
    }
}
