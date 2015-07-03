using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionMethodMapper : MethodMapperBase
    {
        // Sample Collection Constants
        private const string MethodTypeCVSampleCollection = "Specimen collection";
        private const string MethodNameSampleCollection = "Specimen collection";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionMethodMapper(ESDATSampleCollectionParameters parameters)
        {
            _parameters = parameters;
        }

        public override Method Map()
        {
            var entity = Scaffold();
            entity = GetDuplicate(_parameters.DuplicateChecker, entity);

            return entity;
        }

        public override Method Scaffold()
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVSampleCollection;
            method.MethodCode = string.Empty;
            method.MethodName = MethodNameSampleCollection;

            return method;
        }
    }
}
