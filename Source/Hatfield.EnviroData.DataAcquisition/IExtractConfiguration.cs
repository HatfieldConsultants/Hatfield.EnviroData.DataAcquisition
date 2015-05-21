﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.EnviroData.DataAcquisition
{
    public interface IExtractConfiguration
    {
        string PropertyPath { get; }
        IValueAssigner PropertyValueAssigner { get; }
    }
}
