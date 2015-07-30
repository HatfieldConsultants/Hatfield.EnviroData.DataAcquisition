using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using System.Linq.Expressions;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public abstract class ODM2MapperBase<T> where T : class
    {
        public List<IResult> _iResults { get; private set; }
        protected ODM2DuplicateChecker _duplicateChecker;
        protected IWQDefaultValueProvider _WQDefaultValueProvider;
        protected WayToHandleNewData _wayToHandleNewData;

        public ODM2MapperBase(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> iResults)
        {
            _iResults = iResults;
            _duplicateChecker = duplicateChecker;
            _WQDefaultValueProvider = WQDefaultValueProvider;
            _wayToHandleNewData = wayToHandleNewData;
        }

        protected void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }

        private void LogInfo(string message, ODM2ConverterSourceLocation location)
        {
            var resultLevel = ResultLevel.INFO;
            var result = new MappingResult(resultLevel, message, location);

            _iResults.Add(result);
        }

        private void LogError(string message, ODM2ConverterSourceLocation location)
        {
            var resultLevel = ResultLevel.ERROR;
            var result = new MappingResult(resultLevel, message, location);

            _iResults.Add(result);
        }

        private void LogErrorIfNull(object variable, ODM2ConverterSourceLocation location)
        {
            if (variable == null)
            {
                string message = string.Format("{0}: Please specify a non-null value.", location);
                LogError(message, location);
                PrintToConsole(message);
            }
        }

        protected void LogMapping(object variable, ODM2ConverterSourceLocation location)
        {
            string message = string.Format("{0}: Mapped as \"{1}\".", location, variable);
            LogInfo(message, location);
            PrintToConsole(message);
        }

        protected void Validate(object variable, ODM2ConverterSourceLocation location)
        {
            LogErrorIfNull(variable, location);
            LogMapping(variable, location);
        }

        protected static string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;

            return body.Member.Name;
        }

        protected abstract void Validate(T entity);
    }
}
