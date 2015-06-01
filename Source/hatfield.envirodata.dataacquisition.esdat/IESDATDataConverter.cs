using Hatfield.EnviroData.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT
{
    public interface IESDATDataConverter
    {
        IDbContext DbContext { get; }
    }
}
