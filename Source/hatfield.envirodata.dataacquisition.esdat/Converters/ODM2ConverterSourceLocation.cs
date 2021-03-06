﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Hatfield.EnviroData.DataAcquisition;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ODM2ConverterSourceLocation : IDataSourceLocation
    {
        public string Mapper { get; private set; }
        public string Field { get; private set; }

        public ODM2ConverterSourceLocation(string mapper, string field)
        {
            Mapper = mapper;
            Field = field;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Mapper, Field);
        }
    }
}
