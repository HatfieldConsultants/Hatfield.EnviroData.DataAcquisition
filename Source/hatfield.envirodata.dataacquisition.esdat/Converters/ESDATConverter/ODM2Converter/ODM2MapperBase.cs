using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ODM2MapperBase : IESDATDataConverter
    {
        private IDbContext _dbContext;
        protected DuplicateChecker _duplicateChecker;

        public ODM2MapperBase(IDbContext dbContext, DuplicateChecker duplicateChecker)
        {
            _dbContext = dbContext;
            _duplicateChecker = duplicateChecker;
        }

        public IDbContext DbContext
        {
            get { return _dbContext; }
        }
    }
}
