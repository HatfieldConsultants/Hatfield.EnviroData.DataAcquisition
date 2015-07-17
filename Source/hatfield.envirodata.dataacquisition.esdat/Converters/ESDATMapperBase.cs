using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ESDATMapperBase<T> where T : class
    {
        public List<IResult> _results { get; private set; }
        protected ESDATDuplicateChecker _duplicateChecker;
        protected IWQDefaultValueProvider _WQDefaultValueProvider;
        protected WayToHandleNewData _wayToHandleNewData;

        public ESDATMapperBase(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results)
        {
            _results = results;
            _duplicateChecker = duplicateChecker;
            _WQDefaultValueProvider = WQDefaultValueProvider;
            _wayToHandleNewData = wayToHandleNewData;
        }

        protected void LogMappingComplete(object entity)
        {
            var message = entity + ": Mapping complete.";
            var result = new BaseResult(ResultLevel.INFO, message);
            _results.Add(result);

            Console.WriteLine(message);
        }

        protected void LogScaffoldingComplete(object entity)
        {
            var message = entity + ": Scaffolding complete.";
            var result = new BaseResult(ResultLevel.INFO, message);
            _results.Add(result);

            Console.WriteLine(message);
        }

        protected void LogMappingError(MapperSourceLocation location, string details)
        {
            var message = location.Mapper + " (" + location.Field + "): " + details;
            var result = new MappingResult(ResultLevel.ERROR, message, location);
            _results.Add(result);

            Console.WriteLine(message);
        }

        protected void LogNotFoundInDatabaseException(MapperSourceLocation location)
        {
            var message = location.Mapper + ": No duplicate found in database.";
            var result = new MappingResult(ResultLevel.ERROR, message, location);
            _results.Add(result);

            Console.WriteLine(message);
        }
    }
}
