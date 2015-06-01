using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ConverterToODMAction
{
    public class ESDATConverterToODMAction
    {
        protected IDbContext _dbContext;

        public ESDATConverterToODMAction(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
