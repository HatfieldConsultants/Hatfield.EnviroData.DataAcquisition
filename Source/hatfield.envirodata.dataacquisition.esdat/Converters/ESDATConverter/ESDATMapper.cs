using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ESDATMapper : IESDATDataConverter
    {
        private IDbContext _dbContext;
        protected ODM2DuplicateChecker _duplicateChecker;
        protected ESDATLinker _linker;

        public ESDATMapper(IDbContext dbContext, IESDATDataConverterFactory factory, ODM2DuplicateChecker duplicateChecker, ESDATLinker linker)
        {
            if (dbContext != null)
            {
                _dbContext = dbContext;
            }
            else
            {
                throw new ArgumentNullException("Please provide a non-null database context.");
            }

            if (duplicateChecker != null)
            {
                _duplicateChecker = duplicateChecker;
            }
            else
            {
                throw new ArgumentNullException("Please provide a non-null duplicate checker.");
            }

            if (linker != null)
            {
                _linker = linker;
            }
            else
            {
                throw new ArgumentNullException("Please provide a non-null linker.");
            }
        }

        protected T GetDuplicate<T>(T entity, Expression<Func<T, bool>> predicate) where T : class
        {
            return _duplicateChecker.GetDuplicate<T>(entity, predicate);
        }

        public IDbContext DbContext
        {
            get { return _dbContext; }
        }
    }
}
