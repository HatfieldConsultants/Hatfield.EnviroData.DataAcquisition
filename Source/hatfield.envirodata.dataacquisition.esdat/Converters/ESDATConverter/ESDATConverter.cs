using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ESDATConverter : IESDATDataConverter
    {
        private SampleCollectionActionMapper _mapper;

        public ESDATConverter(SampleCollectionActionMapper mapper)
        {
            _mapper = mapper;
        }

        public Core.Action Convert(ESDATModel model)
        {
            return _mapper.Map(model);
        }
    }
}
