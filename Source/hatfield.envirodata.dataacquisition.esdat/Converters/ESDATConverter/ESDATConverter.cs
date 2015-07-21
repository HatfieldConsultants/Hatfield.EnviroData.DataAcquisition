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

        public IEnumerable<IResult> Convert(ESDATModel model)
        {
            return _mapper.Convert(model);
        }

        public Core.Action Map(ESDATModel model)
        {
            return _mapper.Map(model);
        }
    }
}
