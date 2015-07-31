using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryResultMapper : ResultMapperBase, IESDATChemistryMapper<Result>
    {
        public ChemistryResultMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Result Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var result = Draft(esdatModel, chemistry);

            return result;
        }

        public Result Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new Result();

            entity.ResultUUID = Guid.NewGuid();
            entity.ResultTypeCV = _WQDefaultValueProvider.ResultTypeCVChemistry;
            entity.ResultDateTime = chemistry.AnalysedDate;
            entity.SampledMediumCV = _WQDefaultValueProvider.ResultSampledMediumCVChemistry;
            entity.ValueCount = 1;

            Validate(entity);

            return entity;
        }
    }
}
