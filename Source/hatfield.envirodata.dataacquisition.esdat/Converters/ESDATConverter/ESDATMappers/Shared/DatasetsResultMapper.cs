using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class DatasetsResultMapper : DatasetsResultMapperBase
    {
        protected ESDATMapperParametersBase _parameters;

        public DatasetsResultMapper(ESDATMapperParametersBase parameters)
        {
            _parameters = parameters;
        }

        public override DatasetsResult Map()
        {
            var entity = Scaffold();

            return entity;
        }

        public override DatasetsResult Scaffold()
        {
            var entity = new DatasetsResult();

            return entity;
        }
    }
}
