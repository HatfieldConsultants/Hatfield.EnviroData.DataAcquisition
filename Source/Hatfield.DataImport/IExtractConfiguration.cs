using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataImport
{
    public interface IExtractConfiguration
    {
        string PropertyPath { get; }
        IParser PropertyParser { get; }
        IValueAssigner PropertyValueAssigner { get; }
    }
}
