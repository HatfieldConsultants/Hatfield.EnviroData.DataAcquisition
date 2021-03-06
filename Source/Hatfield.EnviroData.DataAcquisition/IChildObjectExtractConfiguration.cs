﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IChildObjectExtractConfiguration : IExtractConfiguration
    {
        IDataImporter ChildObjectImporter { get; }
        Type ChildObjectType { get; }
        IEnumerable<IResult> ExtractData(object model, IDataToImport dataToImport);
    }
}
