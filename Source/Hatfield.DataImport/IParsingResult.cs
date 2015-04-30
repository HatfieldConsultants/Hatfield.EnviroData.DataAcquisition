using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public interface IParsingResult : IResult
    {
        object Value { get; }
    }
}
