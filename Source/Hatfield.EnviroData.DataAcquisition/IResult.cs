using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IResult
    {
        ResultLevel Level { get; }
        string Message { get; }
    }
}
