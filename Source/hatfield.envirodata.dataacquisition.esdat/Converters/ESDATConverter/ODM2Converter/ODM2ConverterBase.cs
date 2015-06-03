using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ODM2ConverterBase : IESDATDataConverter
    {
        protected IDbContext _dbContext;

        public ODM2ConverterBase(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbContext DbContext
        {
            get { return _dbContext; }
        }
    }
}
