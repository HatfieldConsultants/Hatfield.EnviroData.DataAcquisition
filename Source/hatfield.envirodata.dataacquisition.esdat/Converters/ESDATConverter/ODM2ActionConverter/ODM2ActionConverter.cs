using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters.ESDATConverter.ODM2ActionConverter
{
    public class ODM2ActionConverter
    {
        protected IDbContext _dbContext;

        public ODM2ActionConverter(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
