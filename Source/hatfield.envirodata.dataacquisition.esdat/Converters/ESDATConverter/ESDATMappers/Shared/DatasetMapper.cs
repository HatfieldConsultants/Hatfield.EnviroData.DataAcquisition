using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetMapper : DatasetMapperBase
    {
        // Constants
        private const string DatasetTypeCV = "other";

        protected ESDATMapperParametersBase _parameters;

        public DatasetMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override Dataset Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override Dataset Scaffold()
        {
            Dataset dataset = new Dataset();

            dataset.DatasetTypeCV = DatasetTypeCV;
            dataset.DatasetCode = string.Empty;
            dataset.DatasetTitle = string.Empty;
            dataset.DatasetAbstract = string.Empty;

            return dataset;
        }
    }
}
