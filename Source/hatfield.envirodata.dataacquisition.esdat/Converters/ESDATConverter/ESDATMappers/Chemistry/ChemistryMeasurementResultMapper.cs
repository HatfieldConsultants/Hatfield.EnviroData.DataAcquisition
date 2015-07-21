using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hatfield.EnviroData.Core;
using Hatfield.EnviroData.WQDataProfile;

namespace Hatfield.EnviroData.DataAcquisition.ESDAT.Converters
{
    public class ChemistryMeasurementResultMapper : MeasurementResultMapperBase, IESDATChemistryMapper<MeasurementResult>
    {
        public ChemistryMeasurementResultMapper(ESDATDuplicateChecker duplicateChecker, IWQDefaultValueProvider WQDefaultValueProvider, WayToHandleNewData wayToHandleNewData, List<IResult> results) : base(duplicateChecker, WQDefaultValueProvider, wayToHandleNewData, results)
        {
        }

        public MeasurementResult Map(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = Draft(esdatModel, chemistry);

            return entity;
        }

        public MeasurementResult Draft(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var entity = new MeasurementResult();

            entity.CensorCodeCV = _WQDefaultValueProvider.MeasurementResultCensorCodeCVChemistry ;
            entity.QualityCodeCV = _WQDefaultValueProvider.MeasurementResultQualityCodeCVChemistry;
            entity.AggregationStatisticCV = _WQDefaultValueProvider.MeasurementResultAggregationStatisticCVChemistry;

            Validate(entity);

            return entity;
        }
    }
}
