using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMethodMapper : MethodMapperBase, IESDATChemistryMapper<Method>
    {
        public ChemistryMethodMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Method Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Scaffold(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Method Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            Method method = new Method();

            method.MethodID = 0;
            method.MethodTypeCV = _WQDefaultValueProvider.DefaultMethodTypeCVChemistry;
            method.MethodCode = string.Empty;
            method.MethodName = chemistry.MethodName;

            return method;
        }
    }
}
