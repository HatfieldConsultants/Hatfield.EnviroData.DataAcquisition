using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    /// <summary>
    /// Contains converter parameters
    /// Each mapper base is an implementor (bridge design pattern)
    /// </summary>
    public abstract class ODM2MapperParameters
    {
        public IDbContext DbContext { get; protected set; }
        public ODM2DuplicateChecker DuplicateChecker { get; protected set; }
        public ODM2EntityLinker Linker { get; protected set; }
    }
}
