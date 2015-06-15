using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public interface IESDATDataConverterFactory
    {
        IESDATDataConverter BuildESDATMapper(Type dataType, Type odm2DomainType);
    }
}
