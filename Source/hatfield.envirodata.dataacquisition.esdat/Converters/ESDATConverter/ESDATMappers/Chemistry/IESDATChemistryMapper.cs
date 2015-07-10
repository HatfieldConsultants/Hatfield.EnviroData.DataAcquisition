using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public interface IESDATChemistryMapper<T> where T : class
    {
        T Map(ESDATModel esdatModel, ChemistryFileData chemistry);
        T Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry);
    }
}
