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
    public abstract class ESDATMapperParametersBase : ODM2MapperParameters
    {
        public ESDATModel EsdatModel { get; protected set; }
        public SampleFileData SampleFileData { get; set; }
        public ChemistryFileData ChemistryFileData { get; protected set; }
        public Core.Action ParentAction { get; set; }
    }
}
