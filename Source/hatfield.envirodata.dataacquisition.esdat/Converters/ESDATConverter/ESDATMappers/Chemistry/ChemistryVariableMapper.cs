using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryVariableMapper : VariableMapperBase, IESDATChemistryMapper<Variable>
    {
        public ChemistryVariableMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Variable Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);
            entity = GetDuplicate(_wayToHandleNewData, entity);

            return entity;
        }

        public Variable Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Variable();

            entity.VariableTypeCV = _WQDefaultValueProvider.DefaultVariableTypeCVChemistry;
            entity.VariableCode = chemistry.ChemCode;
            entity.VariableNameCV = chemistry.OriginalChemName;
            entity.SpeciationCV = _WQDefaultValueProvider.DefaultVariableSpeciationCV;
            entity.NoDataValue = _WQDefaultValueProvider.DefaultVariableNoDataValue;

            Validate(entity);

            return entity;
        }
    }
}
