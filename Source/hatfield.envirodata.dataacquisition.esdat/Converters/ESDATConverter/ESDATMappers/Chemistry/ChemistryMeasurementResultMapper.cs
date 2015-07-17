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
            var entity = Scaffold(esdatModel, chemistry);

            LogMappingComplete(this);

            return entity;
        }

        public MeasurementResult Scaffold(ESDATModel esdatModel, ChemistryFileData chemistry)
        {
            var measurementResult = new MeasurementResult();

            measurementResult.CensorCodeCV = _WQDefaultValueProvider.MeasurementResultCensorCodeCVChemistry ;
            measurementResult.QualityCodeCV = _WQDefaultValueProvider.MeasurementResultQualityCodeCVChemistry;
            measurementResult.AggregationStatisticCV = _WQDefaultValueProvider.MeasurementResultAggregationStatisticCVChemistry;

            LogScaffoldingComplete(this);

            return measurementResult;
        }
    }
}
