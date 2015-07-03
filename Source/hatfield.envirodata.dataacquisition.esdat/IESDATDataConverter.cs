using Hatfield.EnviroData.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IESDATDataConverter
    {
        Core.Action Convert(ESDATSampleCollectionParameters parameters);
    }
}
