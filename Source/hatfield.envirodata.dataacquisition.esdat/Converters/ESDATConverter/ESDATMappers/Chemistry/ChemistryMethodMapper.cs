using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMethodMapper : MethodMapperBase
    {
        // Chemistry Constants
        private const string MethodTypeCVChemistry = "Specimen analysis";

        protected ESDATChemistryParameters _parameters;

        public ChemistryMethodMapper(ESDATChemistryParameters parameters)
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

            var chemistry = _parameters.ChemistryFileData;

            method.MethodID = 0;
            method.MethodTypeCV = MethodTypeCVChemistry;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            return method;
        }
    }
}
