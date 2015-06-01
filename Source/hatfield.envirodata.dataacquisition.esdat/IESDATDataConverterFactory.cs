using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public interface IESDATDataConverterFactory
    {
        IESDATDataConverter BuildDataConverter(Type dataType, Type odm2DomainType);
    }
}
