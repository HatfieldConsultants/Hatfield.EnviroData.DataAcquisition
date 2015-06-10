using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DataSetsResultMapper : ODM2MapperBase
    {
        public DataSetsResultMapper(IDbContext dbContext, DuplicateChecker duplicateChecker)
            : base(dbContext, duplicateChecker)
        {
        }

        public DataSetsResult Map(ChemistryFileData chemistry, Result result, IESDATDataConverterFactory factory)
        {
            var entity = this.Scaffold(chemistry);

            var dataSetMapper = factory.BuildDataConverter(typeof(ESDATModel), typeof(DataSet)) as DatasetMapper;
            var dataSet = dataSetMapper.Map(entity, chemistry);

            return this.Link(entity, dataSet, result);
        }

        public DataSetsResult Scaffold(ChemistryFileData chemistry)
        {
            return new DataSetsResult();
        }

        public DataSetsResult Link(DataSetsResult entity, DataSet dataSet, Result result)
        {
            entity.DataSet = dataSet;
            entity.DataSetID = dataSet.DataSetID;

            entity.Result = result;
            entity.ResultID = result.ResultID;

            return entity;
        }
    }
}
