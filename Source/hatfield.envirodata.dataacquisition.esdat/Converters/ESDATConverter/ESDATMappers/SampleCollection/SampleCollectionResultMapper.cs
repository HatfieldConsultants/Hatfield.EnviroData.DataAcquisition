using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionResultMapper : ResultMapperBase
    {
        // Constants
        private const string ResultTypeCV = "measurement";
        private const string SampledMediumCV = "Liquid aqueous";

        protected ESDATSampleCollectionParameters _parameters;

        public SampleCollectionResultMapper(ESDATSampleCollectionParameters parameters)
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

            var parameters = _parameters as ESDATSampleCollectionParameters;
            var sample = parameters.SampleFileData;

            result.ResultTypeCV = ResultTypeCV;
            result.ResultDateTime = sample.SampledDateTime;
            result.SampledMediumCV = SampledMediumCV;
            result.ValueCount = 1;

            return result;
        }
    }
}
