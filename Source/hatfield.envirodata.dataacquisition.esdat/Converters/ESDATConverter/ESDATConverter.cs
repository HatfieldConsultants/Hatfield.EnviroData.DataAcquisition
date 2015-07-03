using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATConverter : IESDATDataConverter
    {
        public Core.Action Convert(ESDATSampleCollectionParameters parameters)
        {
            var factory = new ESDATSampleCollectionMapperSingletonFactory(parameters);
            var mapper = new SampleCollectionActionMapper(factory, parameters);

            return mapper.Map();
        }
    }
}
