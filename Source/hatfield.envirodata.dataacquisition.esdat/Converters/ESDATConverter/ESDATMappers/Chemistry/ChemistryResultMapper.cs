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
        public ChemistryResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Result Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var result = Scaffold(esdatModel, chemistry);

            LogMappingComplete(this);

            return result;
        }

        public Result Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var result = new Result();

            result.ResultTypeCV = _WQDefaultValueProvider.ResultTypeCVChemistry;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = _WQDefaultValueProvider.ResultSampledMediumCVChemistry;
            result.ValueCount = 1;

            LogScaffoldingComplete(this);

            return result;
        }
    }
}
