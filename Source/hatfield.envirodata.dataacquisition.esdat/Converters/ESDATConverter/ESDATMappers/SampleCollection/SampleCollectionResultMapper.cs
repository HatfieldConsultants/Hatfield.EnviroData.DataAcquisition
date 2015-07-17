using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class SampleCollectionResultMapper : ResultMapperBase, IESDATSampleCollectionMapper<Result>
    {
        public SampleFileData Sample { get; set; }

        public SampleCollectionResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Result Map(ESDATModel esdatModel)
        {
            var result = Scaffold(esdatModel);

            LogMappingComplete(this);

            return result;
        }

        public Result Scaffold(ESDATModel esdatModel)
        {
            var result = new Result();

            result.ResultTypeCV = _WQDefaultValueProvider.ResultTypeCVSampleCollection;
            result.ResultDateTime = Sample.SampledDateTime;
            result.SampledMediumCV = _WQDefaultValueProvider.ResultSampledMediumCVSampleCollection;
            result.ValueCount = 1;

            LogScaffoldingComplete(this);

            return result;
        }
    }
}
