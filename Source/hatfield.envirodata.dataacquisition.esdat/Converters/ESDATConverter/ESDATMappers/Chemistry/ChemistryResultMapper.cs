using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryResultMapper : ResultMapperBase
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "Liquid aqueous";

        protected ESDATChemistryParameters _parameters;

        public ChemistryResultMapper(ESDATChemistryParameters parameters)
        {
            _parameters = parameters;
        }

        public override Result Map()
        {
            var result = Scaffold();

            return result;
        }

        public override Result Scaffold()
        {
            var result = new Result();

            var chemistry = _parameters.ChemistryFileData;

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = chemistry.AnalysedDate;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            return result;
        }
    }
}
