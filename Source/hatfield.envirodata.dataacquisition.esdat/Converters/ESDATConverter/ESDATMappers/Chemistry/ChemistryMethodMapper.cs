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
        public ChemistryMethodMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Method Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Method Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Method();

            entity.MethodID = 0;
            entity.MethodTypeCV = _WQDefaultValueProvider.DefaultMethodTypeCVChemistry;
            entity.MethodCode = chemistry.MethodType;
            entity.MethodName = chemistry.MethodName;

            Validate(entity);

            return entity;
        }
    }
}
