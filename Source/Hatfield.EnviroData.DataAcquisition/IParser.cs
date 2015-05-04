using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IParser
    {
        IResult Parse(IDataToImport dataToImport, IDataSourceLocation dataSourceLocation, Type type);
    }
}
