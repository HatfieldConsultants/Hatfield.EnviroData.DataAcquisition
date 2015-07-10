using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IESDATSampleCollectionMapper<T> where T : class
    {
        T Map(ESDATModel esdatModel);
        T Scaffold(ESDATModel esdatModel);
    }
}
