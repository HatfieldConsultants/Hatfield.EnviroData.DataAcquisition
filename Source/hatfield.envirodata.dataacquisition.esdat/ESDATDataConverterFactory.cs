using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public class ESDATDataConverterFactory : IESDATDataConverterFactory
    {
        public IESDATDataConverter BuildDataConverter(Type dataType, Type odm2DomainType)
        {
            throw new NotImplementedException();
        }
    }
}
