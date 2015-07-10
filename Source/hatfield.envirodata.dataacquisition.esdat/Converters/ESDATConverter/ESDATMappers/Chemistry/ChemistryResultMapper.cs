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
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "Liquid aqueous";

        public ChemistryResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData)
        {
        }

        public Result Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var result = Scaffold(esdatModel, chemistry);

            return result;
        }

        public Result Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var result = new Result();

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            return result;
        }
    }
}
