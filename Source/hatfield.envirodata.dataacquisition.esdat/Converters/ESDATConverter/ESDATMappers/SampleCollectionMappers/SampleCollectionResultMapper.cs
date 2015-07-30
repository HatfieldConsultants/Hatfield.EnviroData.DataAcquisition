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

        public SampleCollectionResultMapper(ODM2DuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public Result Map(ESDATModel esdatModel)
        {
            var result = Draft(esdatModel);

            return result;
        }

        public Result Draft(ESDATModel esdatModel)
        {
            var entity = new Result();

            entity.ResultUUID = Guid.NewGuid();
            entity.ResultTypeCV = _WQDefaultValueProvider.ResultTypeCVSampleCollection;
            entity.ResultDateTime = Sample.SampledDateTime;
            entity.SampledMediumCV = _WQDefaultValueProvider.ResultSampledMediumCVSampleCollection;
            entity.ValueCount = 1;

            Validate(entity);

            return entity;
        }
    }
}
